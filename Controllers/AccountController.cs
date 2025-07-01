using Microsoft.AspNetCore.Mvc;
using CorretoraDeImoveis.Data; // Esta linha resolve o erro
using CorretoraDeImoveis.Models;

namespace CorretoraDeImoveis.Controllers
{
    public class AccountController : Controller
    {
        public object BrokerRepository { get; private set; }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Client client)
        {
            if (ModelState.IsValid)
            {
                BrokerRepository.AddClient(client);
                return RedirectToAction("RegisterSuccess");
            }

            return View(client);
        }

        public IActionResult RegisterSuccess()
        {
            return View();
        }
    }
}