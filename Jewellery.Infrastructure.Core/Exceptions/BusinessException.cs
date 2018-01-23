using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Infrastructure.Core.Exceptions
{
    public class BusinessException: Exception
    {
        public BusinessException(string message): base(message)
        {

        }

        public BusinessException(string format, params object[] args): base(string.Format(format, args))
        {

        }
    }
}
