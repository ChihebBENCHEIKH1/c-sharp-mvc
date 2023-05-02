using gestion_de_stock.Data;
using gestion_de_stock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Entity;
using System.Net.Sockets;

namespace gestion_de_stock.Controllers
{
    public class ClientController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ClientController(AppDbContext context)
        {
            appDbContext = context;
        }

        public IActionResult Create()
        {
            var products = appDbContext.Products.ToList();
            //ViewBag.IdClient = idClient;
            var productQuantities = new Dictionary<int, int>();
            ViewBag.Produits = new SelectList(products, "IdProduit", "NomProduit", null, "PrixUnit");
            foreach (var product in products)
            {
                productQuantities.Add(product.IdProduit, product.Quantite);
            }
            ViewBag.ProductQuantities = productQuantities;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Commande commande)
        {
            int idClient = (int)HttpContext.Session.GetInt32("idClient");
            Console.WriteLine(idClient);
            var produit = appDbContext.Products.Find(commande.idProduit);
            produit.Quantite -=(int) commande.quantiteDemandee;
            appDbContext.Products.Update(produit);
            commande.idClient = idClient;
            appDbContext.Commandes.Add(commande);
            appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index), new { id = idClient });
        }
        public IActionResult Edit(int id)
        {
            var commande = appDbContext.Commandes.Find(id);
            var products = appDbContext.Products.ToList();
            //ViewBag.IdClient = idClient;
            var productQuantities = new Dictionary<int, int>();
            ViewBag.Produits = new SelectList(products, "IdProduit", "NomProduit", null, "PrixUnit");
            foreach (var product in products)
            {
                productQuantities.Add(product.IdProduit, product.Quantite);
            }
            ViewBag.ProductQuantities = productQuantities;
            return View(commande);
        }
        [HttpPost]
        public IActionResult Edit(Commande commande)
        {
            int idClient = (int)HttpContext.Session.GetInt32("idClient");
            commande.idClient = idClient;
            appDbContext.Commandes.Update(commande);
            appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index), new { id = idClient });

        }
        public IActionResult Index(int id)
        {
            HttpContext.Session.SetInt32("idClient", id);
            var client = appDbContext.Customers.Find(id);
            ViewBag.NomClient = client?.Nom + " " + client?.Prenom;

            var commandes = appDbContext.Commandes.Where(c => c.idClient == id).ToList();

            return View(commandes);
        }
        public IActionResult Redirect()
        {
            int idClient = (int)HttpContext.Session.GetInt32("idClient");
            return RedirectToAction(nameof(Index), new { id = idClient });
        }
        public IActionResult Delete(int id)
        {
            int idClient = (int)HttpContext.Session.GetInt32("idClient");
            appDbContext.Commandes.Remove(appDbContext.Commandes.Find(id));
            appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index), new { id = idClient });
        }
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
