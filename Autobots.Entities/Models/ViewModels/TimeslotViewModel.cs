using Autobots.Entities.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.ViewModels
{
    public class TimeslotViewModel
    {
       
        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }

        public List<TimingSlot> timelist { get; set; }

        public TimeslotViewModel()
        {
            timelist = new List<TimingSlot>();
        }

    }
}