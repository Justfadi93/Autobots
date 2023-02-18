using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.DataAccess.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        IQueryable<T> Get();
        IQueryable<T> GetAll();
        T Get(int id);
        T Update(T obj);
        T Insert(T obj);
        int Remove(T obj);
        T Delete(T obj);

    }
}
