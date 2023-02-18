using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Autobots.Entities.Context;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class Order :  EntityBase
    {
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        

        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }
        public int Millage { get; set; }
        public decimal Price { get; set; }

        public int TimeSlotId { get; set; }
        [ForeignKey("TimeSlotId")]
        public virtual TimingSlot TimingSlot { get; set; }




        public int? ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual CarModel CarModel { get; set; }


        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [InverseProperty("Order")]
        public virtual ICollection<OrderServiceCharge> OrderServiceCharges { get; set; }


        public int status { get; set; }
        public int rating { get; set; }


    }
}