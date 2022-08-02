using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexnoStore.Core.Extention
{
    public static class DataReaderExtensions
    {
        public static T Get<T>(this SqlDataReader reader, string columnName)
        {
            var val = reader[columnName];

            T result = default;

            if (val != DBNull.Value && val != null)
            {
                result = (T)val;
            }
            return result;
        }
    }
}
