using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NET_Core_QuickChart.ChartService;
using NET_Core_QuickChart.ChartService.ChartModels;
using NET_Core_QuickChart.ChartService.ChartModels.Chart_Instances;
using NET_Core_QuickChart.ChartService.Helper;
using NET_Core_QuickChart.Data.Entities;
using NET_Core_QuickChart.Data.Repositories;
using NET_Core_QuickChart.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChartService _chartService;


        public HomeController(ILogger<HomeController> logger,
            IChartService chartService)
        {
            _logger = logger;
            _chartService = chartService;

        }

        public async Task<IActionResult> Index()
        {
            var consoleGamesChart =  _chartService.GetConsoleGamesChart();
            var videoGameDeveloperChart = _chartService.GetVideoGameDeveloperChart();
            var videoGameRatingChart = _chartService.GetVideoGameRatingChart();

            await Task.WhenAll(consoleGamesChart,
                videoGameDeveloperChart, videoGameRatingChart);

            var viewModel = new ChartViewModel
            {
                Charts = new List<ClientResponseModel> { consoleGamesChart.Result,
                videoGameDeveloperChart.Result, videoGameRatingChart.Result  }
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
