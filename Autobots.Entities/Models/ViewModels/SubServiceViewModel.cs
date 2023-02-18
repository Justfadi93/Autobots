using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class SubServiceViewModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public int serviceid { get; set; }

        public List<SubService> subserviceslist { get; set; }

        public SubServiceViewModel()
        {
            subserviceslist = new List<SubService>();
        }

    }
}