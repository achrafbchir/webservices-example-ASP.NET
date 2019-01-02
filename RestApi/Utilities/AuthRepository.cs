using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace RestApi.Utilities
{
    public class AuthRepository : IDisposable
    {
        //private Db authContext;
        
        ///static List<User> users = new List<User>();

        private UserManager<ApplicationUser> userManager;

        public AuthRepository()
        {
            //users 
        }

        public  Boolean RegisterUser(User userModel)
        {
            
            Boolean found = Repository.Repository.Users.Exists(user=> user.Name == userModel.Name);
            if(found)
                return false;
            try
            {
                Repository.Repository.AddNewUser(userModel);
            }
            catch(Exception e)
            {
                var em = e.Message;
                return false;
            }
            return true;
        }

        public User FindUser(string Email, string password)
        {
            var user =  Repository.Repository.Users.Where(c => c.Name == Email && c.Password == password).FirstOrDefault();
            return user != null ?  user : null;
        }

        public void Dispose()
        {
            //authContext.Dispose();
           // userManager.Dispose();
        }
    }
}