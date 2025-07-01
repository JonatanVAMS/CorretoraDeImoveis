using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CorretoraDeImoveis.Data;
using CorretoraDeImoveis.Models;
using System.Text;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CorretoraDeImoveis.Controllers
{
    public class PropertyController : Controller
    {
        public ActionResult Index(int? categoryId)
        {
            var allProperties = BrokerRepository.GetAllProperties();

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                allProperties = allProperties.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            ViewBag.Categories = new SelectList(BrokerRepository.GetAllCategories(), "CategoryId", "Name");

            return View(allProperties);
        }

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(BrokerRepository.GetAllCategories(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Property property)
        {
            if (ModelState.IsValid)
            {
                BrokerRepository.AddProperty(property);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(BrokerRepository.GetAllCategories(), "CategoryId", "Name", property.CategoryId);
            return View(property);
        }

        public ActionResult ExportAsCsv()
        {
            var properties = BrokerRepository.GetAllProperties();
            var sb = new StringBuilder();

            sb.AppendLine("ID;Titulo;Endereco;Quartos;Banheiros;Vagas;Categoria;Descricao");

            foreach (var prop in properties)
            {
                sb.AppendLine($"{prop.PropertyId};{prop.Title};{prop.Address};{prop.Bedrooms};{prop.Bathrooms};{prop.ParkingSpaces};{prop.Category?.Name};\"{prop.Description.Replace("\"", "\"\"")}\"");
            }

            return File(Encoding.UTF8.GetBytes(sb.ToString()), "text/csv", "imoveis.csv");
        }

        public ActionResult ExportAsJson()
        {
            var properties = BrokerRepository.GetAllProperties();
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };
            var jsonString = JsonSerializer.Serialize(properties, options);

            return File(Encoding.UTF8.GetBytes(jsonString), "application/json", "imoveis.json");
        }

        public ActionResult ExportAsSimpleReport()
        {
            var properties = BrokerRepository.GetAllProperties();
            var stringBuilder = new StringBuilder();
            var separatorLine = "--------------------------------------------------";

            foreach (var property in properties)
            {
                stringBuilder.AppendLine(separatorLine);
                stringBuilder.AppendLine($"[ PROPERTY ID: {property.PropertyId} ]");
                stringBuilder.AppendLine(separatorLine);
                stringBuilder.AppendLine("Título       : " + property.Title);
                stringBuilder.AppendLine("Endereço     : " + property.Address);
                stringBuilder.AppendLine("Categoria    : " + property.Category?.Name);
                stringBuilder.AppendLine("Quartos      : " + property.Bedrooms);
                stringBuilder.AppendLine("Banheiros    : " + property.Bathrooms);
                stringBuilder.AppendLine("Vagas        : " + property.ParkingSpaces);
                stringBuilder.AppendLine("Descrição    : " + property.Description);
                stringBuilder.AppendLine();
                stringBuilder.AppendLine();
            }

            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString()), "text/plain", "relatorio_imoveis.txt");
        }
    }
}