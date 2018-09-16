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
    public class BestellPositionRepository : DataRepository<bestellposition>
    {
        public override List<bestellposition> GetAll(Func<bestellposition, bool> where = null)
        {
            using (var ctx = new ErpContext())
            {
                IEnumerable<bestellposition> baseQuery = ctx.bestellposition
                    .Include(b => b.artikel)
                    .Include(b => b.bestellung)
                    .Include(b => b.kundenpreis)
                    .Include(b => b.lagerposition);

                if (where != null)
                    baseQuery = baseQuery.Where(where);

                return baseQuery.ToList();
            }
        }

        public override bestellposition GetSingle(int id)
        {
            using (var ctx = new ErpContext())
            {
                return ctx.bestellposition
                    .Include(b => b.artikel)
                    .Include(b => b.bestellung)
                    .Include(b => b.kundenpreis)
                    .Include(b => b.lagerposition)
                    .FirstOrDefault(p => p.Id == id);
            }
        }

        public override bestellposition Create(bestellposition p)
        {
            return AddOrUpdateBestellposition(p);
        }
        public override void Update(bestellposition p)
        {
            AddOrUpdateBestellposition(p);
        }

        private bestellposition AddOrUpdateBestellposition(bestellposition p)
        {
            using (var ctx = new ErpContext())
            {
                p.bestellung = ctx.bestellung.Find(p.bestellung.Id);
                p.artikel = ctx.artikel.Find(p.artikel.Id);
                p.lagerposition = ctx.lagerposition.Find(p.lagerposition.Id);

                if (p.kundenpreis.Rabatt > 0)
                {
                    var kundenPreis = p.kundenpreis;
                    kundenPreis.artikel = p.artikel;
                    kundenPreis.kunde = p.bestellung.kunde;
                    kundenPreis.Waehrung = "CHF";

                    ctx.kundenpreis.Add(kundenPreis);
                    ctx.SaveChanges();
                    p.kundenpreis = ctx.kundenpreis.Find(p.kundenpreis.Id);
                    p.fk_Bestellposition_KundenPreis = p.kundenpreis.Id;
                }
                else if (p.fk_Bestellposition_KundenPreis > 0)
                {
                    ctx.kundenpreis.AddOrUpdate(p.kundenpreis);
                    ctx.SaveChanges();
                }
                else
                {
                    p.kundenpreis = null;
                }

                ctx.bestellposition.AddOrUpdate(p);
                ctx.SaveChanges();
                return GetSingle(p.Id);
            }
        }


    }
}
