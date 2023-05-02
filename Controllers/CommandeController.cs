using gestion_de_stock.Data;
using Microsoft.AspNetCore.Mvc;

namespace gestion_de_stock.Controllers
{
    public class CommandeController : Controller
    {
        private readonly AppDbContext appDbContext;
        public CommandeController(AppDbContext context)
        {
            appDbContext = context;
        }
        public IActionResult Index()
        {
            var commandes = appDbContext.Commandes.ToList();
            return View(commandes);
        }
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
