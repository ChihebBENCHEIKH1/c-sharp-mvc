using gestion_de_stock.Data;
using gestion_de_stock.Models;
using Microsoft.AspNetCore.Mvc;

namespace gestion_de_stock.Controllers
{
    public class ProduitController : Controller
    {
        private readonly AppDbContext appDbContext;

        public ProduitController(AppDbContext context)
        {
            appDbContext = context;
        }

        public IActionResult Index()
        {
            var produits = appDbContext.Products.ToList();
            return View(produits);
        }
        public IActionResult Edit(int id)
        {
            var produit = appDbContext.Products.Find(id);
            return View(produit);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Produit produit)
        {
          
                appDbContext.Products.Add(produit);
                appDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
          
        }

        [HttpPost]
        public IActionResult Edit(Produit produit)
        {
           
                appDbContext.Products.Update(produit);
                appDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
          
        }
        public IActionResult Delete(int id)
        {
            appDbContext.Products.Remove(appDbContext.Products.Find(id));
            appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Index(string s)
        {
            string name = Request.Form["search"];
            var produits = appDbContext.Products.ToList();
            if (!string.IsNullOrEmpty(name))
            {
                produits = produits.Where(c => c.NomProduit.Contains(name)).ToList();
            }

            return View(produits);
        }
    }
}
