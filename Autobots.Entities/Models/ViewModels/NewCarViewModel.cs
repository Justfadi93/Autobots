using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class NewCarViewModel
    {

        public int makeid { get; set; }
        public int modelid { get; set; }
        public int year { get; set; }
        public int millege { get; set; }

        public List<Car> carlist { get; set; }
        public NewCarViewModel()
        {
            carlist = new List<Car>();
        }
      
    }
}