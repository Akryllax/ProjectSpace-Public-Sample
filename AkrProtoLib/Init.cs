using NetworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkrProtoLib
{
    public static class Init
    {
        public static CoreStatus coreStatus = CoreStatus.Instance;

        public static void InitializeDLL()
        {
            //Load configs

            //Load PP/PF
            List<BaseVisitor> baseVisitorsList = new List<BaseVisitor>();
            baseVisitorsList.Add(new NullVisitor());
            baseVisitorsList.AddRange(BaseTransactionProcessor.GetInstances<BaseVisitor>().ToArray());
            coreStatus.allVisitors = baseVisitorsList.ToArray();

            //Connect to relevant things
        }

        public static void ReleaseDLL()
        {
            //Clean up as a nice person
        }
    }
}
