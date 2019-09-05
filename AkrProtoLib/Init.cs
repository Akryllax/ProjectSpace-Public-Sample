using AkrProtoLib.Base;
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
        public static CoreStatus coreStatus
        {
            get
            {
                if(_coreStatus == null)
                {
                    _coreStatus = CoreStatus.Instance;
                }

                return _coreStatus;
            }
        }

        private static CoreStatus _coreStatus;

        public static void InitializeDLL()
        {
            //Load configs

            //Load PP/PF
            List<BaseVisitor> baseVisitorsList = new List<BaseVisitor>();
            baseVisitorsList.Add(new NullVisitor());
            baseVisitorsList.AddRange(BaseTransactionProcessor.GetInstances<BaseVisitor>().ToArray());
            coreStatus.allVisitors = baseVisitorsList.ToArray();

            ProgramPathDescriptor.Initialize();

            //Connect to relevant things
        }

        public static void ReleaseDLL()
        {
            //Clean up as a nice person
        }
    }
}
