using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class SubService : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }


        public int ServiceId { get; set; }
        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }



        [InverseProperty("SubService")]
        public virtual ICollection<PriceChart> Prices { get; set; }
    }
}