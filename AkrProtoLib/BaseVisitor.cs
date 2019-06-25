using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetworkCore
{
    public abstract class BaseVisitor
    {
        public int VisitorID = -1;

        public abstract void VisitTransaction(ref BaseTransaction transaction);
    }
}
