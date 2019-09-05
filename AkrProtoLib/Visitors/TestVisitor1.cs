using AkrProtoLib.Base;
using NetworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkrProtoLib.Visitors
{
    public class TestVisitor1 : BaseVisitor
    {
        public override int VisitorID { get { return 10; } }

        public override void VisitTransaction(ref BaseTransaction transaction)
        {
            transaction.AddComponent<Test1TransactionComponent>();
        }
    }
}
