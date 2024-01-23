using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TaxiBooking.Models.Entities
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext() :base("DefaultConnection")
        {
           
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Car> Cars { get; set; }
    }
}

