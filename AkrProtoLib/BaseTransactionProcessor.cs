using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCore
{
    public abstract class BaseTransactionProcessor
    {
        protected abstract void ProcessTransaction(BaseTransaction transaction);
    }
}
