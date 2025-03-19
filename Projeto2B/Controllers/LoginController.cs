using Microsoft.AspNetCore.Mvc;

namespace Projeto2B.Controllers
{
    //O nome da controller vai ser sempre PascalCase: MinhaVariavel, camelCase: minhaVariavel

    public class LoginController : Controller //Controller sempre vai ser publica
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
