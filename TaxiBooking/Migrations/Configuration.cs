namespace TaxiBooking.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TaxiBooking.Models.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected   override void Seed(ApplicationDbContext context)
        {
          

            try
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                var user = new User { UserName= "Admin", FirstName = "Admin", LastName = "Manger", Email = "Admin@example.com" };
                  userManager.Create(user,"P@ssw0rd");

                context.Users.AddOrUpdate(u => u.Email, user);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var validationError in error.ValidationErrors)
                    {
                        Console.WriteLine($"Entity: {error.Entry.Entity.GetType().Name}, Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }

                // Handle the exception or log it as needed
            }
        }
    }
}
