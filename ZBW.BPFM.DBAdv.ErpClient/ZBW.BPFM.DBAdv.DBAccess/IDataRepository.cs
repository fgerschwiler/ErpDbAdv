using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ZBW.BPFM.DBAdv.DBAccess
{
    public interface IDataRepository<T>
    {
        List<T> GetAll(Expression<Func<T, bool>> where = null);
        T GetSingle(int id);
        T Create(T obj);
        void Remove(T obj);
        void Update(T obj);
    }
}