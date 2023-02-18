using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class Service : EntityBase
    {
        public string Name { get; set; }
        public string IconClass { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAddOn { get; set; }
        public int? ParentServiceId { get; set; }
        [ForeignKey("ParentServiceId")]
        public virtual Service ParentService { get; set; }
        [InverseProperty("ParentService")]
        public virtual ICollection<Service> AdOns { get; set; }
        [InverseProperty("Service")]
        public virtual ICollection<SubService> SubService { get; set; }
    }
}