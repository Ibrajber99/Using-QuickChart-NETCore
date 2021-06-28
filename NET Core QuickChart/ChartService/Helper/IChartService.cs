using NET_Core_QuickChart.ChartService.ChartModels.Chart_Instances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService.Helper
{
    public interface IChartService
    {
        //Chart methods
        ChartBase GetVideoGameRatings();

        ChartBase GetVideoGameDeveloper();

        ChartBase GetConsoleGames();



        //Chart generation methods
        Task<ClientResponseModel> GetVideoGameRatingChart();

        Task<ClientResponseModel> GetVideoGameDeveloperChart();

        Task<ClientResponseModel> GetConsoleGamesChart();

        //Chart Generator
        ChartBase GetChartInstance(string type, List<string> labels, List<int> data);


    }
}
