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
            return dbContext.products.ToList();
        }

        public static product GetProduct(Guid id)
        {
            return dbContext.products.Where(c => c.C_Id == id).FirstOrDefault();
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
    }
}