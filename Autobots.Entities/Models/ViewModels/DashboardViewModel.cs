using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class DashboardViewModel
    {

        public List<Order> listofbookings { get; set; }

        public List<DbOrdersChart> ListofStats { get; set; }

        public DashboardViewModel()
        {
            listofbookings = new List<Order>();
            ListofStats = new List<DbOrdersChart>();

        }

    }
}