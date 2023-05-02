using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using gestion_de_stock.Data;
using gestion_de_stock.Models;

namespace gestion_de_stock.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext appDbContext;

        public AdminController(AppDbContext context)
        {
            appDbContext = context;
        }

        public IActionResult Index()
        {
            var clients = appDbContext.Customers.ToList();
            return View(clients);
        }
        public IActionResult Edit(int id)
        {
            var client = appDbContext.Customers.Find(id);
            return View(client);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Client client)
        {
         
                appDbContext.Customers.Add(client);
                appDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
        
        }
        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Edit(Client client)
        {
           
       
                Console.WriteLine(client.Addresse);
                appDbContext.Customers.Update(client);
                appDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
         
        }
        public IActionResult Delete(int id)
        {
            appDbContext.Customers.Remove(appDbContext.Customers.Find(id));
            appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Index(string s)
        {
            string name = Request.Form["search"];
            var customers = appDbContext.Customers.ToList();
            if (!string.IsNullOrEmpty(name))
            {
                customers = customers.Where(c => c.Nom.Contains(name)).ToList();
            }

            return View(customers);
        }

    }
}
