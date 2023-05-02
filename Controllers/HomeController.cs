using gestion_de_stock.Data;
using gestion_de_stock.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using gestion_de_stock.Models;
namespace gestion_de_stock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext appDbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            appDbContext = context;
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            Debug.WriteLine($"Username: {username}, Password: {password}");

            var user = appDbContext.Admins.SingleOrDefault(u => u.Nom == username && u.Numero.ToString() == password);
            if(user!=null)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                var client=appDbContext.Customers.SingleOrDefault(u => u.Nom == username && u.Numero.ToString() == password);
                return RedirectToAction("Index", "Client", new { id = client.IdClient });
            }
           
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
    }
}