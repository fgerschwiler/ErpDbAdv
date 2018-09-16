using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ZBW.BPFM.DBAdv.DBAccess
{
    public class LagerpositionRepository : DataRepository<lagerposition>
    {
        public override List<lagerposition> GetAll(Func<lagerposition, bool> where = null)
        {
            using (var ctx = new ErpContext())
            {
                IEnumerable<lagerposition> baseQuery = ctx.lagerposition
                    .Include(x => x.lager).ToList();

                if (where != null)
                    baseQuery = baseQuery.Where(where);

                return baseQuery.ToList();
            }
        }

        public override lagerposition GetSingle(int id)
        {
            using (var ctx = new ErpContext())
            {
                return ctx.lagerposition
                    .Include(l => l.lager)
                    .FirstOrDefault(b => b.Id == id);
            }
        }
       
    }
}
