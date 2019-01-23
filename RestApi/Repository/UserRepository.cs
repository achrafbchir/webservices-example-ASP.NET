using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using WebApplication1.Models;

namespace RestApi.Repository
{
    public class UserRepository
    {
        public static Entities dbContext = new Entities();

        public static user Exists(string name, string password)
        {
            return dbContext.users.Where(c => c.Name == name && c.Password == password).FirstOrDefault();
        }

        public static List<user> Users()
        {
            return dbContext.users.ToList();
        }

        public static void AddNewUser(user user)
        {
            //User newUser = new User(user.Name,user.Password);
            //user.Carte.User = user;
            dbContext.users.Add(user);
            
            //dbContext.SaveChanges();
            
           // CartRepository.AddCarte(carte);
            dbContext.SaveChanges();
        }

        public static void DeleteUser(Guid id)
        {
            user item = dbContext.users.Where(c => c.Id == id).FirstOrDefault();
            if (item != null)
                dbContext.users.Remove(item);
            dbContext.SaveChanges();
        }

        public static user GetUser(Guid id)
        {
            user user = dbContext.users.Where(c => c.Id == id).FirstOrDefault();
            return dbContext.users.Where(c => c.Id == id).FirstOrDefault();
        }

        public static void EditUser(Guid id, user user)
        {
            DeleteUser(id);
            dbContext.users.Add(user);
            dbContext.SaveChanges();
        }
    }
}