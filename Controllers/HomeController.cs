using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Funcionarios.Models;
using Funcionarios.Model;

namespace Funcionarios.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly oficinaContext _context;
        public HomeController(ILogger<HomeController> logger, oficinaContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {


            return View();
        }
        [HttpPost]
        public ContentResult cadastrarOrcamento(Servicos novoAmigo)
        {
            var content = new ContentResult();
           

            _context.Servicos.Add(novoAmigo);
            _context.SaveChanges();

            return content;
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Consulta()
        {
            string sTabela = "";

            var orcamentos = (from O in _context.Servicos select O).OrderBy(x => x.NomeCliente).ToList();
     
            foreach (var trabalho in orcamentos)
            {
                sTabela += "<tr>";
                sTabela += "<td>";
                sTabela += trabalho.NomeCliente;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.DataOrcamento;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.Vendedor;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.DescricaoOrcamento;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += trabalho.ValorOrcado;
                sTabela += "</td>";
                sTabela += "<td>";
                sTabela += "<a onclick='deletar("+trabalho.CodCliente+")'>Excluir</a>";
                sTabela += "</td>";
                sTabela += "</tr>";


            }
            ViewBag.orcamentos = sTabela;
            return View();
        }

     

        public ContentResult deletarOrcamento(int codorcamento)
        {
            var content = new ContentResult();
           
            Servicos servicos_banco = (from S in _context.Servicos where S.CodCliente == codorcamento select S).FirstOrDefault();

            if (servicos_banco != null)
            {
                _context.Servicos.Remove(servicos_banco);
                _context.SaveChanges();
            }
            
            
            
            return content;
        }
    }
    
}
