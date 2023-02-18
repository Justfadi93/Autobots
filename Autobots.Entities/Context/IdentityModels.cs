using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Autobots.Entities.Models.DB;

namespace Autobots.Entities.Context
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
       
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        public string Phone { get; set; }
        public string Address { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Order> Appointments { get; set; }
        public int? usertype { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<PriceChart> PriceChart { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<SubService> SubService { get; set; }
        public DbSet<TimingSlot> TimingSlot { get; set; }
        public DbSet<Subscribers> Subscribers { get; set; }
        public DbSet<CallNumbers> CallNumbers { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<OrderServiceCharge> OrderServiceCharge { get; set; }


    }
}
