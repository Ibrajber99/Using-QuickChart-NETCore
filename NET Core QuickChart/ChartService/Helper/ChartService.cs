using NET_Core_QuickChart.ChartService.ChartModels;
using NET_Core_QuickChart.ChartService.ChartModels.Chart_Instances;
using NET_Core_QuickChart.Data.Entities;
using NET_Core_QuickChart.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.ChartService.Helper
{
    public class ChartService : IChartService
    {
        private readonly IBaseClient<ChartBase> _client;
        private readonly IVideoGameRepo _gameRepo;
        private readonly IGameConsoleRepo _consoleRepo;
        private readonly ChartFactory _chartFactory;

        public ChartService(IBaseClient<ChartBase> client,
            IVideoGameRepo gameRepo,
            IGameConsoleRepo consoleRepo,
            ChartFactory chartFactory)
        {
            _client = client;
            _gameRepo = gameRepo;
            _consoleRepo = consoleRepo;
            _chartFactory = chartFactory;
        }

        #region Charts Methods

        public ChartBase GetVideoGameDeveloper()
        {
            var gamesList = _gameRepo.GetIqeryAble();

            var developerGroup = gamesList.GroupBy(i => i.Developer).OrderBy(i => i.Key);
            var developerList = developerGroup.Select(m => m.Count()).ToList();


            var chart = GetChartInstance("Pie",
               new List<string>(Enum.GetNames(typeof(Developers)).ToList()),
               new List<int>(developerList));

            return chart;
        }

        public ChartBase GetVideoGameRatings()
        {
            var gamesList = _gameRepo.GetIqeryAble();

            var ratingsGroup = gamesList.GroupBy(i => i.Rating).OrderBy(i => i.Key);

            var ratingsList = ratingsGroup.Select(m => m.Count()).ToList();

            var chart = GetChartInstance("Pie", 
                new List<string>(Enum.GetNames(typeof(Rating)).ToList()),
                new List<int>(ratingsList));

            return chart;
        }

        public ChartBase GetConsoleGames()
        {
            var consoleList = _consoleRepo.GetIqeryAble();

            consoleList = consoleList.OrderBy(i => i.ID);

            var consoleName = consoleList.Select(c => c.ConsoleName);

            var consoleGames = consoleList.Select(c => c.VideoGames.Count);


            var chart = GetChartInstance("Doughnut", new List<string>(consoleName),
                new List<int>(consoleGames));

            return chart;
        }

        #endregion

        
        #region Charts Cinversions

        public async Task<ClientResponseModel> GetConsoleGamesChart()
        {
            var consoleGamesChart = GetConsoleGames();

            var response = await _client.GetChartResult(consoleGamesChart);

            return response;
        }

        public async Task<ClientResponseModel> GetVideoGameDeveloperChart()
        {
            var gameDevelopers = GetVideoGameDeveloper();

            var response = await _client.GetChartResult(gameDevelopers);

            return response;
        }

        public async Task<ClientResponseModel> GetVideoGameRatingChart()
        {
            var videoGamesRating = GetVideoGameRatings();

            var response = await _client.GetChartResult(videoGamesRating);

            return response;
        }

        #endregion


        public ChartBase GetChartInstance(string type, List<string> labels, List<int> data)
        {
            var chartInstance = _chartFactory.GetChartInstance(type);

            chartInstance.Data = new DataModel
            {
                Labels = new List<string>(labels),
                Datasets = new List<DataSetModel>{ new DataSetModel
                {Data = new List<int>(data)}}
            };


            return chartInstance;
        }
    }
}
