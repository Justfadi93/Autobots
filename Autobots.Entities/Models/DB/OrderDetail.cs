using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class OrderDetail : EntityBase
    {
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }


        public int SubServiceId { get; set; }
        [ForeignKey("SubServiceId")]
        public virtual SubService SubService { get; set; }

        public decimal Price { get; set; }
    }
}