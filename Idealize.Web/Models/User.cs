using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Idealize.Web.Models
{
    public class User
    {
        public Int32 CodUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Login { get; set; }
        public string CPF { get; set; }
    }
}
