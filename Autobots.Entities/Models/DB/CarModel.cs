using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Autobots.Entities.Models.Defaults;
using System.ComponentModel.DataAnnotations;

namespace Autobots.Entities.Models.DB
{
    public class CarModel : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }


        public int? MakeId { get; set; }
        [ForeignKey("MakeId")]
        public virtual CarMake Make { get; set; }


        [InverseProperty("CarModel")]
        public virtual ICollection<PriceChart> Prices { get; set; }

    }
}