using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.Data.Entities
{
    public class GameConsole
    {

        public GameConsole()
        {
            VideoGames = new List<VideoGame>();
        }

        public int ID { get; set; }

        public string ConsoleName { get; set; }

        public List<VideoGame> VideoGames { get; set; }
    }
}
