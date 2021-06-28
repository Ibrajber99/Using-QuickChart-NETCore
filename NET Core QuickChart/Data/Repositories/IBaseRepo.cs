using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.Data.Repositories
{
    public interface IBaseRepo<T>
    {
        int Save(T item);

        int Delete(T item);

        IQueryable<T> GetIqeryAble();
    }
}
