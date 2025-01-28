using Microsoft.AspNetCore.Mvc;

namespace SistemaEscolar01.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
