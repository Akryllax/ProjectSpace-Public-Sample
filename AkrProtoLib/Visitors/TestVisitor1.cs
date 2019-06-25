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
        public new int VisitorID = 10;

        public override void VisitTransaction(ref BaseTransaction transaction)
        {
            
        }
    }
}
