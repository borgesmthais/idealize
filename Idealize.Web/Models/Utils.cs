using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Idealize.Web.Models
{
    public static class Utils
    {
        public static string Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Decode(string encodedData)
        {
            var encodedBytes = System.Convert.FromBase64String(encodedData);
            return System.Text.Encoding.UTF8.GetString(encodedBytes);
        }
    }
}
