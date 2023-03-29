using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    internal class OrderDominException: Exception
    {
        public OrderDominException()
        {
        }

        public OrderDominException(string message) : base(message)
        {
        }

        public OrderDominException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
