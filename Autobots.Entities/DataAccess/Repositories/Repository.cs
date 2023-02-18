using System;
using System.Collections.Generic;
using System.Linq;
using Autobots.Entities.Context;
using Autobots.Entities.Models.Defaults;

namespace Autobots.Entities.DataAccess.Repositories
{
    
        public abstract class Repository<T> : IRepository<T> where T : EntityBase
        {
            private readonly ApplicationDbContext _db;

            protected Repository(ApplicationDbContext contect)
            {
                _db = contect;
            }

            public virtual IQueryable<T> Get()
            {
                return _db.Set<T>().Where(x => x.IsActive);
            }

            public virtual T Get(int id)
            {
                return _db.Set<T>().Find(id);
            }
            public virtual IQueryable<T> Get(List<int> id)
            {
                return _db.Set<T>().Where(x => id.Contains(x.Id));
            }
            public virtual IQueryable<T> GetAll()
            {
                return _db.Set<T>();
            }


            public virtual T Insert(T obj)
            {
                obj.UpdatedAt = DateTime.Now;
                _db.Set<T>().Add(obj);
                _db.SaveChanges();
                return obj;
            }

            public virtual List<T> InsertRange(List<T> obj)
            {
                foreach (var item in obj)
                    item.UpdatedAt = DateTime.Now;
                _db.Set<T>().AddRange(obj);
                _db.SaveChanges();
                return obj;
            }

            public virtual T Update(T obj)
            {
                obj.UpdatedAt = DateTime.Now;
                _db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return obj;
            }

            public virtual T Delete(T obj)
            {
                obj.IsActive = false;
                _db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return obj;
            }

            public virtual int Remove(T obj)
            {
                _db.Set<T>().Remove(obj);
                return _db.SaveChanges();
            }

            public virtual int RemoveRange(List<T> obj)
            {
                _db.Set<T>().RemoveRange(obj);
                return _db.SaveChanges();
            }
        }
}