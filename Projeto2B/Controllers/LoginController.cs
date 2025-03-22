using Microsoft.AspNetCore.Mvc;
using Projeto2B.Models;
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
            //Ele usa _usuarioRepositorio.ObterUsuario(email) para buscar o usuário no banco de dados.
            var usuario = _usuarioRepositorio.ObterUsuario(email);

            //Se o usuário for encontrado e a senha estiver correta, ele redireciona o usuário para a página inicial (RedirectToAction("Index", "Home")).
            if (usuario != null && usuario.Senha == senha) //Esse simbolo != é sinal de diferente
            {
                // Autenticação bem-sucedida
                return RedirectToAction("Index", "Home");
            }
            //Caso contrário, ele adiciona um erro ao ModelState e retorna a visualização de login, exibindo a mensagem de erro.
            ModelState.AddModelError("", "Email ou senha inválidos.");

            //retorna a visualização (a página HTML) associada a este método
            return View();
        }

        public IActionResult Cadastro ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            //verifica se os dados do usuário são válidos (de acordo com as regras de validação definidas na classe Usuario).
            if (ModelState.IsValid)
            {
                // Se os dados forem válidos, ele usa _usuarioRepositorio.
                // AdicionarUsuario(usuario) para adicionar o novo usuário ao banco de dados e redireciona para a página de login.
                _usuarioRepositorio.AdicionarUsuario(usuario);

                // visualização de cadastro, exibindo os erros de validação

                return RedirectToAction("Login");
            }
            return View(usuario);
        }
    }
}
