using NetworkCore;
using System;

namespace AkrProtoLib
{
    public class NullVisitor : BaseVisitor
    {
        public override int VisitorID { get { return -99; } }

        public override bool CanExecute(ref BaseTransaction transaction)
        {
            return false;
        }

        public override void VisitTransaction(ref BaseTransaction transaction)
        {
            Console.WriteLine("WHAT ARE YOU DOING");
            throw new System.NotImplementedException();
        }
    }
}