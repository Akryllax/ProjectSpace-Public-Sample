using NetworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkrProtoLib.Interfaces
{
    public abstract class BaseVisitable
    {
        public readonly int VisitorID = -1;
        public abstract void VisitMessage(ref BaseTransaction transaction);
    }
}
