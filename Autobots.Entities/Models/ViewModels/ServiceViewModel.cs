using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class ServiceViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsAddOn { get; set; }
        public decimal Price { get; set; }

        public int? ParentServiceId { get; set; }
        [ForeignKey("ParentServiceId")]
        public virtual Service ParentService { get; set; }
        
        [InverseProperty("Service")]
        public virtual ICollection<SubService> SubService { get; set; }

        public List<Service> serviceslist { get; set; }

        public ServiceViewModel()
        {
            serviceslist = new List<Service>();
        }

    }
}