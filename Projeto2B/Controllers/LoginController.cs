using Microsoft.AspNetCore.Mvc;
using Projeto2B.Repositorio;

namespace Projeto2B.Controllers
{
    //O nome da controller vai ser sempre PascalCase: MinhaVariavel, camelCase: minhaVariavel

    // Controller cria a view

    public class LoginController : Controller //Controller sempre vai ser publica
    {
        
        //Declara uma variavel privada somento leitura
        private readonly UsuarioRepositorio _usuarioRepositorio;

        //Construtor
        public LoginController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost] //Manda os dados, envia o usuário e senha 
        public IActionResult Login(String email, string senha)
        {
            return View();
        }

        public IActionResult Cadastro ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
