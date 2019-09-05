using AkrProtoLib.Base;
using NetworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkrProtoLib.Visitors
{
    public class TestVisitor2 : BaseVisitor
    {
        public override int VisitorID { get { return 11; } }

        public override void VisitTransaction(ref BaseTransaction transaction)
        {
            transaction.AddComponent<Test2TransactionComponent>();
        }
    }
}
