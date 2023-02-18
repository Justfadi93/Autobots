using Autobots.Entities.Context;
using Autobots.Entities.Models.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.DB
{
    public class Complaint : EntityBase
    {
        public string complain { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser User { get; set; }
    }
}