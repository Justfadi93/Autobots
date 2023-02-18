using Autobots.Entities.Models.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.DB
{
    public class Booking : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }

    }
}