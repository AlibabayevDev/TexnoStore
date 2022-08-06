using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNull(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}
