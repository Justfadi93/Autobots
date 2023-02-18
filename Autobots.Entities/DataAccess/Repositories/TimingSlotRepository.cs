using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autobots.Entities.Context;
using Autobots.Entities.Models.DB;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.DataAccess.Repositories
{
    public class TimingSlotRepository : Repository<TimingSlot>
    {
        public TimingSlotRepository(ApplicationDbContext contect) : base(contect)
        {
        }
    }
}