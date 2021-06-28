using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.Data.Entities
{
    public class VideoGame
    {
        public int ID { get; set; }

        public Rating Rating { get; set; }

        public string Title { get; set; }

        public Developers Developer { get; set; }

        public GameConsole Console { get; set; }
    }
}
