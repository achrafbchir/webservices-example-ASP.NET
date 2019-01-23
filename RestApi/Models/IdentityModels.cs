using System;
using System.Data.Entity;
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
       
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("defaultConnection", throwIfV1Schema: false)
        {
        }

       // public DbSet<user> Users { get; set; }
       // public DbSet<Cart> Cartes { get; set; }
        //public DbSet<Product> Products { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>()
            //.HasRequired<Carte>(s => s.Carte)
            //.WithMany(g => g.products)
            //.HasForeignKey<Carte>(s => s.Carte);

            // modelBuilder.Entity<User>().HasRequired(s => s.Carte).WithRequiredPrincipal(ad => ad.User);
            //modelBuilder.Entity<User>()
            //    .HasRequired(c=>c.Carte)
            //    .WithRequiredPrincipal(u => u.User);
        }

        //public static ApplicationDbContext Create()
        //{
        //    return new ApplicationDbContext();
        //}
    }
    
}