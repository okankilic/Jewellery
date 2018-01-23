using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Infrastructure.Core.Extensions
{
    public static class StringExtensions
    {
        public static string TrimIfNotNullOrWhiteSpace(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return str.Trim();
        }
    }
}
