using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class OrderViewModel
    {

        public string Name { get; set; }
        public string contact { get; set; }
        public string email { get; set; }

        public int orderid { get; set; }
        public DateTime orderdate { get; set; }
        public string Carmake { get; set; }
        public string timingslot { get; set; }
        public string CarModel { get; set; }
        public string address { get; set; }
        public int year { get; set; }
        public int millage { get; set; }
        public int status { get; set; }
        public int rating { get; set; }

        //public List<int> subservice { get; set; }

        public decimal totalprice { get; set; }

        public List<OrderDetail> pricesofsubservices { get; set; }

        public OrderViewModel()
        {
            pricesofsubservices = new List<OrderDetail>();

        }
    }
}