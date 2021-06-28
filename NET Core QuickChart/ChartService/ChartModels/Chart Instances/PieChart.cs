using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService.ChartModels.Chart_Instances
{
    public class PieChart : ChartBase
    {
        public PieChart()
        {
            Type = "pie";
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
                            align = "bottom",
                            backgroundColor = "#ccc",
                            borderRadius = 6,
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
