using Autobots.Entities.Context;
using Autobots.Entities.Models.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.DB
{
    public class Car : EntityBase
    {
        public int makeid { get; set; }
        public int modelid { get; set; }
        public string CreatedBy  { get; set; }
        [ForeignKey("CreatedBy")]
        public virtual ApplicationUser User { get; set; }
        public int year { get; set; }
        public int millege { get; set; }

        [ForeignKey("modelid")]
        public virtual CarModel CarModel { get; set; }
    }
}