using System.ComponentModel.DataAnnotations.Schema;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class OrderServiceCharge : EntityBase
    {
        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public decimal Price { get; set; }
    }
}