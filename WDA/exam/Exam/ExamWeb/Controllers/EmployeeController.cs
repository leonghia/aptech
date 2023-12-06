using Microsoft.AspNetCore.Mvc;

namespace ExamWeb.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
