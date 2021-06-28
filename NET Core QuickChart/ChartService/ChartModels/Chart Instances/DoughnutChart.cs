using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService.ChartModels.Chart_Instances
{
    public class DoughnutChart : ChartBase
    {
        public DoughnutChart()
        {
            Type = "doughnut";
        }

        public object Options
        {
            get
            {
                return new
                {
                    Plugins = new
                    {
                        datalabels = new
                        {
                            display = true,
                            backgroundColor = "#ccc",
                            borderRadius = 10,
                            font = new
                            {
                                color = "red",
                                size = 12
                            }
                        }
                    }
                };
            }
        }
    }
}
