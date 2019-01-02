using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace RestApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public  int charSum { get; set; }
        public DateTime SumRefDate { get; set; }
        //public string PaysProvenance { get; set; }
        //public string PaysDistination { get; set; }
        //public int Volume { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DB", throwIfV1Schema: false)
        {
        }
        
        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}
    }
    
}