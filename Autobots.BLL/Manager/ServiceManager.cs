using System.Collections.Generic;
using System.Linq;
using Autobots.Entities.DataAccess;
using Autobots.Entities.Models.DB;

namespace Autobots.BLL.Manager
{
    public class ServiceManager
    {
        private DbService _db;

        public ServiceManager()
        {
            _db = new DbService(); 
        }

        public List<Service> GetServices()
        {
            return _db.Services.Get().Where(x=>x.IsActive.Equals(true)).ToList();
        }



    }
}