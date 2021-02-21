using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _16._09._20_ATM
{
    class AmountException : ArgumentException
    {
        public int Value { get; }
        public AmountException(string message, int val): base(message)
        {
            Value = val;
        }
    }

    class PINException : Exception
    {
        public PINException(string message) : base(message)
        {
            
        }
    }

    class RepositoryException : Exception
    {
        public RepositoryException(string message) : base(message)
        {

        }
    }
}
