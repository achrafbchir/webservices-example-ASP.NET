using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class Product
    {
        public Guid _Id;
        public string name;
        public string description;
        public long price;
        public int quantity;


        public Product(Guid Id, string name, string description, long price, int quantity)
        {
            _Id = Id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }
    }
}