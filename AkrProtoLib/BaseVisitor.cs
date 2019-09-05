using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NetworkCore
{
    public abstract class BaseVisitor
    {
        public virtual int VisitorID { get { return -1; } }

        public virtual bool CanExecute(ref BaseTransaction transaction)
        {
            return true;
        }

        public abstract void VisitTransaction(ref BaseTransaction transaction);
    }
}
