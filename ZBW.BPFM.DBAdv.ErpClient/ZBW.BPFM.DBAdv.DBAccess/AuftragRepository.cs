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
    public class AuftragRepository : DataRepository<bestellung>
    {
        public override IEnumerable<bestellung> GetAll(Func<bestellung, bool> where = null)
        {
            using (var ctx = new ErpContext())
            {
                var baseQuery = ctx.bestellung
                    .Include(x => x.kunde.person)
                    .Include(b => b.bestellposition).ToList();

                if (where != null)
                    baseQuery = baseQuery.Where(where).ToList();

                return baseQuery.ToList();
            }
        }

        public override bestellung GetSingle(int id)
        {
            using (var ctx = new ErpContext())
            {
                return ctx.bestellung
                    .Include(b => b.kunde.person)
                    .Include(b => b.bestellposition.Select(p => p.artikel))
                    .Include(b => b.bestellposition.Select(p => p.kundenpreis))
                    .Include(b => b.bestellposition.Select(p => p.lagerposition.lager))
                    .FirstOrDefault(b => b.Id == id);
            }
        }

        public override void Remove(bestellung obj)
        {
            using (var ctx = new ErpContext())
            {
                ctx.bestellung.Attach(obj);

                ctx.Entry(obj).Reload();
                ctx.Entry(obj).Collection(b => b.lieferschein).Load();
                ctx.Entry(obj).Collection(b => b.bestellposition).Load();

                ctx.lieferschein.RemoveRange(obj.lieferschein);
                ctx.bestellposition.RemoveRange(obj.bestellposition);

                ctx.bestellung.Remove(obj);
                ctx.SaveChanges();
            }
        }
    }
}
