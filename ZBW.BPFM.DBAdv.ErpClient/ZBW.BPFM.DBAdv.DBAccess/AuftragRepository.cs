using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZBW.BPFM.DBAdv.DBAccess
{
    public class AuftragRepository
    {
        public List<bestellung> GetAuftraegeAsync()
        {
            using (var ctx = new ErpContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
               return ctx.bestellung
                    .Include(x => x.kunde.person)
                    .Include(b => b.bestellposition)
                    .AsNoTracking()
                    .ToList();

//                ctx.Configuration.LazyLoadingEnabled = true;
            }
        }

        public Task<bestellung> GetBestellungAsync(int id)
        {
            using (var ctx = new ErpContext())
            {
                return ctx.bestellung.FindAsync(id);
            }
        }

        public async Task<bestellung> CreateBestellungAsync(bestellung b)
        {
            using (var ctx = new ErpContext())
            {
                var newBestellung = ctx.bestellung.Add(b);
                await ctx.SaveChangesAsync();
                return newBestellung;
            }
        }


        public async Task DeleteBestellungAsync(bestellung b)
        {
            using (var ctx = new ErpContext())
            {
                ctx.bestellung.Remove(b);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
