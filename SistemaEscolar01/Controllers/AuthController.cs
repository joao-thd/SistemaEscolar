using Microsoft.AspNetCore.Mvc;
using SistemaEscolar01.Models;

namespace SistemaEscolar01.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Professor professor) 
        {
            if (professor.Email == "professor@escola.com" && professor.Senha == "123")
            {
                return RedirectToAction("Index","Professor");
            }
            ModelState.AddModelError("","Email ou senha inválidos.");
            return View();
        }
    }
}
