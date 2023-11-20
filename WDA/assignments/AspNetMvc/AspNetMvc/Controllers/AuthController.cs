using Microsoft.AspNetCore.Mvc;

namespace AspNetMvc.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login() => View();

        public IActionResult Register() => View();

        public IActionResult Index() => View();
    }
}
