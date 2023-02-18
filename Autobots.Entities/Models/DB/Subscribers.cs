using Autobots.Entities.Models.Defaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Autobots.Entities.Models.DB
{
    public class Subscribers: EntityBase
    {
        public string Email { get; set; }
    }
}