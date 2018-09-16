using Ninject.Modules;
using ZBW.BPFM.DBAdv.DBAccess;
using ZBW.BPFM.DBAdv.ErpClient.Pages;

namespace ZBW.BPFM.DBAdv.ErpClient.DI
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataRepository<bestellung>>().To<AuftragRepository>();
            Bind<IDataRepository<bestellposition>>().To<DataRepository<bestellposition>>();
            Bind<AuftragViewModel>().ToSelf();
        }
    }
}
