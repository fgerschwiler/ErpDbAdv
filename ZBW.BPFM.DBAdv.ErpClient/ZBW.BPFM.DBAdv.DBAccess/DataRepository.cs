using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ZBW.BPFM.DBAdv.DBAccess
{
    public class DataRepository<T> : IDataRepository<T> where T: class
    {
        public virtual List<T> GetAll(Func<T, bool> where = null)
        {
            using (var ctx = new ErpContext())
            {
                IEnumerable<T> baseQuery = ctx.Set<T>().ToList();

                if (where != null)
                    baseQuery = baseQuery.Where(where); // running filter in-memory, because of non-db fields like displayname's etc.

                return baseQuery.ToList();
            }
        }

        public virtual T GetSingle(int id)
        {
            using (var ctx = new ErpContext())
            {
                return ctx.Set<T>().Find(id);
            }
        }

        public virtual T Create(T obj)
        {
            using (var ctx = new ErpContext())
            {
                var newObj = ctx.Set<T>().Add(obj);
                ctx.SaveChanges();
                return newObj;
            }
        }

        public virtual void Remove(T obj)
        {
            using (var ctx = new ErpContext())
            {
                ctx.Set<T>().Attach(obj);
                ctx.Set<T>().Remove(obj);
                ctx.SaveChanges();
            }
        }

        public virtual void Update(T obj)
        {
            using (var ctx = new ErpContext())
            {
                ctx.Set<T>().AddOrUpdate(obj);
                ctx.SaveChanges();
            }
        }
    }
}
