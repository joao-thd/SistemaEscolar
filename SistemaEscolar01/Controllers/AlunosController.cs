using Microsoft.AspNetCore.Mvc;
using SistemaEscolar01.Models;

namespace SistemaEscolar01.Controllers
{
    public class AlunosController : Controller
    {
        // Ação de Login
        public IActionResult LoginAluno()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Aluno aluno)
        {
            if (aluno.Email == "aluno@escola.com" && aluno.Senha == "senha123")
            {
                return RedirectToAction("Index", "Alunos"); // Redireciona para a página inicial do aluno
            }

            // Garantir que a View correta seja carregada
            ViewBag.ErrorMessage = "Email ou senha inválidos.";
            return View("LoginAluno");
        }

        // Ação de Index para o painel do aluno
        public IActionResult Index()
        {
            return View(); // Certifique-se de que a View Index.cshtml existe na pasta Views/Alunos
        }
    }
}
