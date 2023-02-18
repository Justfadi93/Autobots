using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.Models.DB
{
    public class TimingSlot : EntityBase
    {
        public string DisplayText { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }

        [InverseProperty("TimingSlot")]
        public virtual ICollection<Order> Appointments { get; set; }
    }
}