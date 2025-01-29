using Microsoft.AspNetCore.Mvc;
using SistemaEscolar01.Models;
using SistemaEscolarV1.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaEscolar01.Controllers
{
    public class ProfessorController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GerenciarNotas()
        {
            var turnos = new List<Turno>
            {
                new Turno { Nome = "Matutino" },
                new Turno { Nome = "Vespertino" },
                new Turno { Nome = "Noturno" }
            };
            return View(turnos);
        } //Exibir Turnos no painel de gerenciar notas

        public IActionResult EscolherAno(string turnoescolhido)
        {
            Console.WriteLine($"Turno Escolhido: {turnoescolhido}");

            // Verifique também se o valor está correto.
            if (string.IsNullOrEmpty(turnoescolhido))
            {
                return RedirectToAction("GerenciarNotas");
            }

            var anosFundamental = new List<string>
    {
        "1º Ano do Fundamental", "2º Ano do Fundamental", "3º Ano do Fundamental",
        "4º Ano do Fundamental", "5º Ano do Fundamental", "6º Ano do Fundamental",
        "7º Ano do Fundamental", "8º Ano do Fundamental", "9º Ano do Fundamental"
    };

            var anosEnsinoMedio = new List<string>
    {
        "1º Ano do Ensino Médio", "2º Ano do Ensino Médio", "3º Ano do Ensino Médio"
    };

            ViewBag.TurnoEscolhido = turnoescolhido;
            ViewBag.AnosFundamental = anosFundamental;
            ViewBag.AnosEnsinoMedio = anosEnsinoMedio;

            return View();
        }


    }
}

