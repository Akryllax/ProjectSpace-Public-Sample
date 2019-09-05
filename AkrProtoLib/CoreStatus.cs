using AkrProtoLib.Base;
using NetworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkrProtoLib
{
    public class CoreStatus
    {
        public BaseVisitor[] allVisitors;

        private static readonly CoreStatus instance = new CoreStatus();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        private CoreStatus() { }

        public static CoreStatus Instance
        {
            get
            {
                return instance;
            }
        }

        //TODO PLEASE CLEAN UP THIS MESS
        public ref BaseVisitor GetVisitor(int ID)
        {
            int index = -1;
            for (int i = 0; i < allVisitors.Length; i++)
            {
                if(allVisitors[i].VisitorID == ID)
                {
                    index = i;
                    break;
                }
            }

            if(index != -1)
            {
                return ref allVisitors[index];
            } else
            {
                return ref GetVisitor(-99);
            }
        }
    }
}
