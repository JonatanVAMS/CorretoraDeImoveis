using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CorretoraDeImoveis.Dados;
using CorretoraDeImoveis.Models;
using System.Text;
using System;
using System.Linq;

namespace CorretoraDeImoveis.Controllers
{
    public class ImoveisController : Controller
    {
        public ActionResult Index()
        {
            var imoveis = ImovelRepositorio.ObterTodosImoveis();
            return View(imoveis);
        }

        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(ImovelRepositorio.ObterTodasCategorias(), "CategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                ImovelRepositorio.AdicionarImovel(imovel);
                return RedirectToAction("Index"); 
            }


            ViewBag.CategoriaId = new SelectList(ImovelRepositorio.ObterTodasCategorias(), "CategoriaId", "Nome", imovel.CategoriaId);
            return View(imovel);
        }

        public ActionResult ExportarTxt()
        {
            var imoveis = ImovelRepositorio.ObterTodosImoveis();
            var sb = new StringBuilder();
            var linhaSeparadora = "--------------------------------------------------";

            foreach (var imovel in imoveis)
            {

                sb.AppendLine(linhaSeparadora);
                sb.AppendLine($"[ IMÓVEL ID: {imovel.ImovelId} ]");
                sb.AppendLine(linhaSeparadora);

                sb.AppendLine("Título   : " + imovel.Nome);
                sb.AppendLine("Endereço : " + imovel.Endereco);
                sb.AppendLine("Categoria: " + imovel.Categoria.Nome);
                sb.AppendLine("Quartos  : " + imovel.NroQuartos);
                sb.AppendLine("Banheiros: " + imovel.NroBanheiros);
                sb.AppendLine("Vagas    : " + imovel.NroVagasGaragem);
                sb.AppendLine("Descrição: " + imovel.Descricao);

                sb.AppendLine();
                sb.AppendLine();
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/plain", "imoveis.txt");
        }
    }
}