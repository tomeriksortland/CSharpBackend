using System;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Endre noe som alt ligger i databasen.
            var db = new NorthwindContext();
            var edit = db.Products.First();
            edit.ProductName += "*";
            db.SaveChanges();

            
            return;

            // Slette noe i databasen.
            var first = db.Products.First();
            db.Products.Remove(first);
            db.SaveChanges();


            return;

            //Skrive til databasen (Helt spesifikt lage et nytt produkt) 
            
            var entity = new Products()
            {
                ProductName = "TomErikTest"
            };
            db.Products.Add(entity);
           await db.SaveChangesAsync();


            return;

            //Hente ut info fra databasen.
            var products = 
                db.Products
                .Include(p=>p.Category)
                .ThenInclude(c => c.Products)
                .Include(p => p.Supplier)
                .Take(10);

            foreach (var product in products)
            {
                Console.WriteLine("Produkt: " + product.ProductName);
                Console.WriteLine("Kategori: " + product.Category.CategoryName);
                Console.WriteLine("Annet produkt i samme kategori: " + product.Category.Products.Skip(1).First().ProductName);
            }
            
        }
    }
}
