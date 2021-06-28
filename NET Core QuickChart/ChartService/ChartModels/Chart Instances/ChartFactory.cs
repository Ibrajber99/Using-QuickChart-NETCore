using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService.ChartModels.Chart_Instances
{
    public class ChartFactory 
    {
        public ChartBase GetChartInstance(string userSelection)
        {
            if (userSelection == "Pie")
                return new PieChart();

            return new DoughnutChart();
        }
    }
}
