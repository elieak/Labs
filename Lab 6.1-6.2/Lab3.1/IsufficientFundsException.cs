using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Account
{
    class IsufficientFundsException : Exception
    {
        public IsufficientFundsException()
        {
        }

        public IsufficientFundsException(string message)
            : base(message)
        {
            
        }
    }
}
