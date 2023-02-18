using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class CarMake : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }


        [InverseProperty("Make")]
        public virtual ICollection<CarModel> Models { get; set; }

        
    }
}