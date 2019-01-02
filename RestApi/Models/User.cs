using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        public Guid Id;
        public string Name;
        public string Password;
        public List<Product> products;

        public User(Guid id, string name, string password)
        {
            Id = id;
            Name = name;
            Password = password;
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Product item = products.Where(c => c._Id == product._Id).FirstOrDefault();
            if(item == null)
            {
                products.Add(product);
            }
        }

        public void DeleteProduct(Product product)
        {
            Product item = products.Where(c => c._Id == product._Id).FirstOrDefault();
            if (item != null)
            {
                products.Remove(product);
            }
        }

    }
}