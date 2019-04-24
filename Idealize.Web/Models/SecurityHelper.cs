using System.Web;
using Idealize.Web.Models;
using Microsoft.AspNetCore.Http;
using Sistema.Arquitetura.Library.Core.Util.Security;

namespace Idealize.Web.Models
{
    public static class SecurityHelper
    {
        public static ObjectSecurity GetObjectSecurity()
        {
            User obj = new User();
            return (new ObjectSecurity()
            {
                UserSystem = obj.CodUsuario,
                IdAluno = obj.CodUsuario,
                Login = obj.Login,
                Nome = obj.NomeUsuario
            });
        }

        public static void SetUserLogged(User objUsuario)
        {
            //HttpContext.Current.Session["UsuarioLogado"] = objUsuario;
            //HttpContext.Current.Session["CodUsuario"] = objUsuario.CodUsuario;
            //HttpContext.Current.Session["Login"] = objUsuario.Login;
            //HttpContext.Current.Session["cpf"] = objUsuario.CPF;
        }

        public static User getUserLogged()
        {

            //if (HttpContext.Current != null && HttpContext.Current.Session["UsuarioLogado"] is User)
            //{
            //    User obj = (User)HttpContext.Current.Session["UsuarioLogado"];
            //    return obj;
            //}
            return new User();
        }

    }

}
