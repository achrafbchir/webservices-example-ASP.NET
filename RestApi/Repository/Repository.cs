using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace RestApi.Repository
{
    public class Repository
    {
        public static List<Product> Products = new List<Product>
        {
            new Product (Guid.NewGuid(),"TV Samsung 42","Profitez d’un divertissement à domicile encore plus époustouflant et plus réaliste que jamais.",6290,25),
            new Product ( Guid.NewGuid(),  "LG Refrigerateur 360 L",  "L'air frais circule facilement avec des sorties au niveau de chaque clayette pour gagner en performance avec une descente en température plus rapide.", 7650, 32),
            new Product ( Guid.NewGuid(),"LG Refrigerateur 300 L", "L'air frais circule facilement avec des sorties au niveau de chaque clayette pour gagner en performance avec une descente en température plus rapide.", 7650,32 ),
            new Product ( Guid.NewGuid(),"Lave Linge Electrolux 8Kg", "Trouvez le lave-linge qui vous convient le mieux. Un appareil qui adapte la lessive à votre emploi du temps. Donnez un coup de jeune à vos vêtements à l'aide de la vapeur.", 5,18 ),
            new Product ( Guid.NewGuid(),"Lave Linge Whirlpool 5Kg", "Le lave linge Whirlpool AWE5213 blanc, est une machine à laver top dotée d'une capacité de lavage de 5 kg. Il accueille jusqu'à 5 kg de linge pour seulement 40 cm de large.", 4200,15 ),

        };
        public static List<User> Users = new List<User>
        {
            new User (Guid.NewGuid(),"User1","Password1"),
            new User ( Guid.NewGuid(),  "User2",  "Password2"),

        };

        public static User Exists(string name,string password)
        {
           
            return Users.Where(c => c.Name == name && c.Password == password).FirstOrDefault();
        }
        public static void AddNewUser(User user)
        {

            user.Id = Guid.NewGuid();
            Users.Add(user);
        }

        public static void DeleteUser(Guid id)
        {
            User item = Users.Where(c => c.Id == id).FirstOrDefault();
            if (item != null)
                Users.Remove(item);
        }

        public static User GetUser(Guid id)
        {
            return Users.Where(c => c.Id == id).FirstOrDefault();
        }

        public static void EditUser(Guid id, User user)
        {
            Delete(id);
            Users.Add(user);
        }

        public static void AddProduct(Guid id, Product product)
        {
            Boolean exists = Users.Exists(c => c.Id == id);
            if (exists)
            {
                Users.Where(c => c.Id == id).FirstOrDefault().AddProduct(product);
            }
        }

        public static void RemoveProduct(Guid id, Guid product)
        {
            Boolean exists = Users.Exists(c => c.Id == id);
            Boolean existProdut = Products.Exists(c => c._Id == id);
            if (exists && existProdut)
            {
                Product MyProduct = Products.Where(c => c._Id == id).FirstOrDefault();
                Users.Where(c => c.Id == id).FirstOrDefault().DeleteProduct(MyProduct);
            }
        }

        public static void AddNewProduct(Product product)
        {

            product._Id = Guid.NewGuid();
            Products.Add(product);
        }

        public static void Delete(Guid id)
        {
            Product item = Products.Where(c => c._Id == id).FirstOrDefault();
            if (item != null)
                Products.Remove(item);
        }

        public static Product GetProduct(Guid id)
        {
            return Products.Where(c => c._Id == id).FirstOrDefault();
        }

        public static void Edit(Guid id, Product product)
        {
            int index = Products.FindIndex(c => c._Id == id);
            //Products.Remove(Products.Where(c=>c._Id == id).FirstOrDefault());
            //Products.Add(product);           
            Delete(id);
            product._Id = id;
            Products.Insert(index, product);
        }

        public static List<Product> getUserProducts(Guid id)
        {
            return GetUser(id).products;
        }
    }
}