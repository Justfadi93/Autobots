using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public string Name { get; set; }
        public string contact { get; set; }
        public string email { get; set; }

        public int orderid { get; set; }

        public int make_id { get; set; }
        public int timings { get; set; }
        public int model_id { get; set; }
        public string address { get; set; }
        public int year { get; set; }
        public int millage { get; set; }
        //public List<int> subservice { get; set; }
        public decimal price { get; set; }
        public string selectedsubservices { get; set; }



    }
}