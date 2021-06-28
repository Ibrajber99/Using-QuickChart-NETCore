using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService.ChartModels.Chart_Instances
{
    public abstract class ChartBase
    {
        public string Type { get; set; }

        public DataModel Data { get; set; }
    }
}
