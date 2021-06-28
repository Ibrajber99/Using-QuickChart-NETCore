using NET_Core_QuickChart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.Data.Repositories
{
    public class GameConsoleRepo : IGameConsoleRepo
    {

        public List<GameConsole> _gameConsoleList;

        public GameConsoleRepo()
        {
            _gameConsoleList = new List<GameConsole>();
            Save(new GameConsole 
                { ID = 0, ConsoleName = "PlayStation 5",
                  VideoGames = new List<VideoGame> 
                  { new VideoGame { ID = 1,Rating= Rating.Bad,Title ="Call of duty Bo2"},
                   new VideoGame {ID = 2,Rating= Rating.Great,Title ="Call of duty Bo3" },
                   new VideoGame {ID = 3,Rating= Rating.Good,Title ="Call of duty Bo4" } }
            });

            Save(new GameConsole 
                { ID = 0, ConsoleName = "PlayStation 4",
                VideoGames = new List<VideoGame>
                  { new VideoGame { ID = 4,Rating= Rating.Good,Title ="Call of duty Bo5"},
                   new VideoGame {ID = 5,Rating= Rating.Great,Title ="Assasins creed 1"},
                   new VideoGame {ID = 6,Rating= Rating.Bad,Title = "Assasins creed 2" } }
            });

            Save(new GameConsole 
                { ID = 0, ConsoleName = "Xbox One",
                VideoGames = new List<VideoGame>
                  { new VideoGame {ID = 7,Rating= Rating.Bad,Title = "Assasins creed 3"},
                   new VideoGame {ID = 8,Rating= Rating.Great,Title = "Assasins creed Brotherhood"},
                   new VideoGame {ID = 9,Rating= Rating.Good,Title ="Battlefield 3" } }
            });

            Save(new GameConsole 
                { ID = 0, ConsoleName = "Xbox Series X",
                VideoGames = new List<VideoGame>
                  { new VideoGame {  ID = 0,Rating= Rating.Bad,Title = "Battlefield 4" },
                   new VideoGame {ID = 0,Rating= Rating.Good,Title = "Battlefield 5" }}
            });

        }


        public int Delete(GameConsole item)
        {
            var foundGame = _gameConsoleList.FirstOrDefault(i => i.ID == item.ID);

            if (foundGame == null)
            {
                return 0;
            }
            else
            {
                _gameConsoleList.Remove(foundGame);

                return 1;
            }
        }

        
        public IQueryable<GameConsole> GetIqeryAble()
        {
            var queryAble = _gameConsoleList.AsQueryable();
            return queryAble;
        }


        public int Save(GameConsole item)
        {
            if (item.ID == 0 && _gameConsoleList.Count == 0)
            {
                item.ID = 1;
                _gameConsoleList.Add(item);
                return 1;
            }
            else if (item.ID > 0)
            {
                var foundUpdatedGame = _gameConsoleList
                        .FirstOrDefault(i => i.ID == item.ID);

                if (foundUpdatedGame != null)
                {
                    foundUpdatedGame = item;
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                var maxNum = _gameConsoleList.Max(v => v.ID);
                item.ID = maxNum + 1;
                _gameConsoleList.Add(item);
                return 1;
            }

        }
    }
}
