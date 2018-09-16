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
    public class KundeRepository : DataRepository<kunde>
    {
        public override List<kunde> GetAll(Func<kunde, bool> where = null)
        {
            using (var ctx = new ErpContext())
            {
                IEnumerable<kunde> baseQuery = ctx.kunde
                    .Include(x => x.person).ToList();

                if (where != null)
                    baseQuery = baseQuery.Where(where);

                return baseQuery.ToList();
            }
        }

        public override kunde GetSingle(int id)
        {
            using (var ctx = new ErpContext())
            {
                return ctx.kunde
                    .Include(l => l.person)
                    .FirstOrDefault(b => b.Id == id);
            }
        }
       
    }
}
