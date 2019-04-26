using Microsoft.AspNetCore.Mvc;
using Idealize.VO;
using Idealize.Web.Models;
using Idealize.BO;

namespace Idealize.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Funcionario loginFuncionario)
        {
            var senhaDescriptografada = loginFuncionario.senha;
            var senhaCriptografada = Utils.Encode(senhaDescriptografada);
            loginFuncionario.senha = senhaCriptografada;

            Funcionario funcionario = new Funcionario();
            FuncionarioBO boFuncionario = new FuncionarioBO(SecurityHelper.GetObjectSecurity());

            funcionario = boFuncionario.autenticaLogin(loginFuncionario);

            if (funcionario == null)
            {
                TempData["mensagemErroLogin"] = "Login Inválido";
                return View();
            }

            TempData["nomeUsuario"] = loginFuncionario.login.ToString();

            return RedirectToAction("Index", "Home");
        }
    }
}