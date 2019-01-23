using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace RestApi.Repository
{
  
    public class CartRepository
    {
        //public static ApplicationDbContext dbContext = new ApplicationDbContext();

        public static Entities dbContext = new Entities();

        public static void AddProduct(Guid id, product product)
        {
            user user = UserRepository.GetUser(id);


            if (user != null)
            {
                

                var CartId = user.Cart_CartId;
                List<item> items = dbContext.items.Where(i => i.Cart_CartId == CartId).ToList();

                var item = items.Exists(i => i.product_Id == product.C_Id);

                product stock = dbContext.products.Where(p => p.C_Id == product.C_Id).FirstOrDefault();

                if (!item)
                {
                    var newitem = new item();
                    newitem.ItemId = Guid.NewGuid();
                    newitem.Cart_CartId = product.C_Id;
                    newitem.cart = dbContext.users.Where(u => u.Id == id).FirstOrDefault().cart;
                    newitem.product_Id = product.C_Id;
                    newitem.quantity = 0;
                    dbContext.items.Add(newitem);

                    stock.quantity--;
                    dbContext.SaveChanges();
                }
                else if(item  && stock.quantity > 1)
                {
                    item myitem = dbContext.items.Where(i => i.product_Id == product.C_Id && i.Cart_CartId == CartId).FirstOrDefault();
                    myitem.quantity++;
                    stock.quantity--;
                    dbContext.SaveChanges();
                }
                
            }
        }

        public static void RemoveProduct(Guid id, Guid product)
        {
            user user = UserRepository.GetUser(id);
            if(user != null)
            {
                var CartId = user.Cart_CartId;
                item item = dbContext.items.Where(i => i.Cart_CartId == CartId && i.product_Id == product).FirstOrDefault();
                if (item.quantity > 1)
                    item.quantity--;
                else
                    dbContext.items.Remove(item);
                dbContext.SaveChanges();

            }

         
        }

        public static List<product> getUserProducts(Guid id)
        {
            user user = UserRepository.GetUser(id);
            var CartId = user.Cart_CartId;
            if (CartId == null)
                return null;
            
            List<item> items = dbContext.items.Where(i => i.Cart_CartId == CartId).Distinct().ToList();
            
            List<product> products = new List<product>();
            foreach (item item in items)
            {
                product product = ProductRepository.GetProduct((Guid)item.product_Id);
                product.quantity = item.quantity;
                products.Add(product);
            }
                
            return products;
        }
    }
}