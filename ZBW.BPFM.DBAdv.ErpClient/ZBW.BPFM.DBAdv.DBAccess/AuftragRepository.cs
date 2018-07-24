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
        public IQueryable<Bestellung> GetAuftraegeAsQueryable()
        {
            using (var ctx = new ErpContext())
            {
                return ctx.Bestellung.AsQueryable();
            }
        }

        public Task<Bestellung> GetBestellungAsync(int id)
        {
            using (var ctx = new ErpContext())
            {
                return ctx.Bestellung.FindAsync(id);
            }
        }

        public async Task<Bestellung> CreateBestellungAsync(Bestellung b)
        {
            using (var ctx = new ErpContext())
            {
                var newBestellung = ctx.Bestellung.Add(b);
                await ctx.SaveChangesAsync();
                return newBestellung;
            }
        }


        public async Task DeleteBestellungAsync(Bestellung b)
        {
            using (var ctx = new ErpContext())
            {
                ctx.Bestellung.Remove(b);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
