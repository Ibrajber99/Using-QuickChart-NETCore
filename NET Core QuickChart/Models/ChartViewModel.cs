using NET_Core_QuickChart.ChartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.Models
{
    public class ChartViewModel
    {

        public ChartViewModel()
        {
            Charts = new List<ClientResponseModel>();
        }

        public List<ClientResponseModel> Charts { get; set; }
    }
}
