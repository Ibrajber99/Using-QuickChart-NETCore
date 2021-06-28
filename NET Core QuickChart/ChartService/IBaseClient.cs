using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService
{
    public interface IBaseClient<T>
    {
        Task<ClientResponseModel> GetChartResult(T item);
    }
}
