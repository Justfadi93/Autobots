
using System;

namespace Autobots.Entities.Migrations
{
    using Context;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            try
            {

                if (!context.Roles.Any(r => r.Name == "Admin"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "Admin" };
                    manager.Create(role);
                }
                if (!context.Roles.Any(r => r.Name == "Customer"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "Customer" };
                    manager.Create(role);
                }
                if (!context.Roles.Any(r => r.Name == "Employee"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "Employee" };
                    manager.Create(role);
                }
                if (!context.Roles.Any(r => r.Name == "CustomUser"))
                {
                    var store = new RoleStore<IdentityRole>(context);
                    var manager = new RoleManager<IdentityRole>(store);
                    var role = new IdentityRole { Name = "CustomUser" };
                    manager.Create(role);
                }

                context.SaveChanges();

                if (!context.Users.Any(u => u.UserName == "Admin"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var user = new ApplicationUser
                    {
                        UserName = "Admin",
                        FirstName = "AFname",
                        LastName = "ALname",
                        //CreatedAt = DateTime.Now,
                        Email = "Admin@123.com",
                        EmailConfirmed = true,
                        IsActive = true,CreatedAt = DateTime.Now
                    };
                    manager.Create(user, "Admin@123");
                    manager.AddToRole(user.Id, "Admin");
                }
                //context.SaveChanges();

                if (!context.Users.Any(u => u.UserName == "Customer"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var user = new ApplicationUser
                    {
                        UserName = "Customer",
                        FirstName = "Fname",
                        LastName = "UserN",
                        Email = "Customer@123.com",
                        EmailConfirmed = true,
                        IsActive = true,CreatedAt = DateTime.Now
                    };
                    manager.Create(user, "Customer@123");
                    manager.AddToRole(user.Id, "Customer");
                }
                if (!context.Users.Any(u => u.UserName == "Employee"))
                {
                    var store = new UserStore<ApplicationUser>(context);
                    var manager = new UserManager<ApplicationUser>(store);
                    var user = new ApplicationUser
                    {
                        UserName = "Employee",
                        FirstName = "Fname",
                        LastName = "UserN",
                        Email = "Employee@123.com",
                        EmailConfirmed = true,
                        IsActive = true,CreatedAt = DateTime.Now
                    };
                    manager.Create(user, "Employee@123");
                    manager.AddToRole(user.Id, "Employee");
                }

                context.SaveChanges();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException);
                throw e;
            }
        }
    }
}
