using NetworkCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace AkrProtoLib.Base
{
    class VisitorInstanceDescriptor
    {
        public int VisitorID;
        public BaseVisitor VisitorInstance;
    }

    public class ProgramPathDescriptor
    {
        public static SortedList<int, ProgramPathDescriptor> programPaths = new SortedList<int, ProgramPathDescriptor>();

        public int ProgramPathID = -1;

        protected List<BaseVisitor> programItems = new List<BaseVisitor>();

        public void AddVisitorInstance(BaseVisitor visitor)
        {
            this.programItems.Add(visitor);
        }

        public void ProcessTransaction(ref BaseTransaction baseTransaction)
        {
            foreach (BaseVisitor vi in programItems)
            {
                if(vi.CanExecute(ref baseTransaction))
                { 
                    vi.VisitTransaction(ref baseTransaction);
                }
            }
        }

        public static void Initialize()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlPPList;

            FileStream fs = new FileStream("C:/Users/alexm/Documents/Project Space/AkrProtoLib/Config/ProgramPaths.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlPPList = xmldoc.GetElementsByTagName("ProgramPath");

            for (int i = 0; i < xmlPPList.Count; i++)
            {
                ProgramPathDescriptor programPathDescriptor = new ProgramPathDescriptor
                {
                    ProgramPathID = int.Parse(xmlPPList[i].Attributes["ID"].Value)
                };

                XmlNodeList xmlVIList = xmlPPList[i].ChildNodes;
                for (int j = 0; j < xmlVIList.Count; j++)
                {
                    int visitorID = int.Parse(xmlVIList[j].Attributes["ID"].Value);
                    string DefaultReturn = xmlVIList[j].Attributes["DefaultReturn"].Value;
                    string ErrorReturn = xmlVIList[j].Attributes["ErrorReturn"].Value;

                    VisitorInstanceDescriptor visitorInstance = new VisitorInstanceDescriptor
                    {
                        VisitorID = visitorID,
                        VisitorInstance = CoreStatus.Instance.GetVisitor(visitorID)
                    };

                    programPathDescriptor.AddVisitorInstance(visitorInstance.VisitorInstance);
                }

                programPaths.Add(programPathDescriptor.ProgramPathID, programPathDescriptor);
            }
        }
    }
}
