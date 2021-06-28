using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService.ChartModels
{
    public class DataModel
    {
        public List<string> Labels { get; set; }

        public List<DataSetModel> Datasets { get; set; }
    }
}
