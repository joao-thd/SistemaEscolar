using Microsoft.AspNetCore.Mvc;
using SistemaEscolarV1.Models;
using System.Linq;

namespace SistemaEscolar01.Controllers
{
    public class ProfessorController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


        // Lista de notas simulando um banco de dados
        private static List<Nota> _notas = new List<Nota>
        {
            new Nota { Id = 1, AlunoNome = "João Silva", Valor = 7.5m },
            new Nota { Id = 2, AlunoNome = "Maria Oliveira", Valor = 8.9m }
        };

        // Exibe a página de gerenciamento de notas
        public IActionResult GerenciarNotas()
        {
            
            return View(_notas);
        }

        // Exibe o formulário para adicionar uma nova nota
        [HttpGet]
        public IActionResult AdicionarNota()
        {
            return View();
        }

        // Adiciona uma nova nota
        [HttpPost]
        public IActionResult AdicionarNota(int alunoId, decimal nota)
        {
            // Valida os dados antes de adicionar
            if (alunoId <= 0 || nota < 0 || nota > 10)
            {
                ModelState.AddModelError("", "Nota inválida.");
                return View(); // Retorna a mesma view com o erro
            }

            
            var alunoNome = "Aluno Exemplo"; 

            var novaNota = new Nota
            {
                Id = _notas.Max(n => n.Id) + 1, 
                AlunoNome = alunoNome,
                Valor = nota
            };

           
            _notas.Add(novaNota);

            // Redireciona para a página de gerenciamento de notas
            return RedirectToAction("GerenciarNotas");
        }

        // Exibe a página de edição de nota
        [HttpGet]
        public IActionResult Editar(int id)
        {
            var nota = _notas.FirstOrDefault(n => n.Id == id);
            if (nota == null)
            {
                return NotFound();  
            }
            return View(nota); 
        }

        // Salva as alterações feitas na nota
        [HttpPost]
        public IActionResult Editar(Nota nota)
        {
            // Valida os dados antes de salvar
            if (nota.Valor < 0 || nota.Valor > 10)
            {
                ModelState.AddModelError("", "Nota inválida.");
                return View(nota);  
            }

            var notaExistente = _notas.FirstOrDefault(n => n.Id == nota.Id);
            if (notaExistente == null)
            {
                return NotFound();
            }

            // Atualiza a nota
            notaExistente.Valor = nota.Valor;

            
            return RedirectToAction("GerenciarNotas");
        }

        // Exclui uma nota
        [HttpPost]
        public IActionResult Excluir(int id)
        {
            var nota = _notas.FirstOrDefault(n => n.Id == id);
            if (nota == null)
            {
                return NotFound();
            }

            
            _notas.Remove(nota);

            // Redireciona para a página de gerenciamento de notas
            return RedirectToAction("GerenciarNotas");
        }
    }
}
