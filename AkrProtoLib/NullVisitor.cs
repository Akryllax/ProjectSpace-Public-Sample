using NetworkCore;
using System;

namespace AkrProtoLib
{
    public class NullVisitor : BaseVisitor
    {
        public new int VisitorID = -99;

        public override void VisitTransaction(ref BaseTransaction transaction)
        {
            Console.WriteLine("WHAT ARE YOU DOING");
            throw new System.NotImplementedException();
        }
    }
}