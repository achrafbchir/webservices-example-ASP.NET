using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Repository
{
    public class ProductRepository
    {
        public static Entities dbContext = new Entities();

        public static List<product> Products()
        {
            Entities db = new Entities();
            return db.products.ToList();
        }

        public static product GetProduct(Guid id)
        {
            Entities db = new Entities();
            return db.products.Where(c => c.C_Id == id).FirstOrDefault();
        }

        public static void Edit(Guid id, product product)
        {
            Delete(id);
            dbContext.products.Add(product);
            dbContext.SaveChanges();
        }

        public static void AddNewProduct(product product)
        {

            product.C_Id = Guid.NewGuid();
            dbContext.products.Add(product);
            dbContext.SaveChanges();
        }

        public static void Delete(Guid id)
        {
            product item = dbContext.products.Where(c => c.C_Id == id).FirstOrDefault();
            if (item != null)
                dbContext.products.Remove(item);
            dbContext.SaveChanges();
        }

        public static List<product> Paginate(int page, int count)
        {
            int indexPage = page <= 0 ? 1 : page;
            count = count < 0 ? 20 : count;
            List<product> products = dbContext.products.Where(p=>p.quantity > 0 ).OrderBy(c => c.quantity).Skip((indexPage - 1) * count).Take(count).ToList();
            return products;
        }
    }
}