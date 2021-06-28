using NET_Core_QuickChart.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_QuickChart.Data.Repositories
{
    public class VideoGameRepo : IVideoGameRepo
    {
        private List<VideoGame> _videoGameList;

        public VideoGameRepo()
        {
 
            _videoGameList = new List<VideoGame>();

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Bad,Title ="Call of duty Bo2",Developer = Developers.Activison });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Great, Title ="Call of duty Bo3", Developer = Developers.Activison });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Good, Title ="Call of duty Bo4", Developer = Developers.Activison });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Good, Title ="Call of duty Bo5", Developer = Developers.Activison });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Great, Title ="Assasins creed 1", Developer = Developers.Ubisoft });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Bad, Title = "Assasins creed 2", Developer = Developers.Ubisoft });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Bad, Title = "Assasins creed 3",Developer = Developers.Ubisoft });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Great, Title = "Assasins creed Brotherhood", Developer = Developers.Ubisoft });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Good,Title ="Battlefield 3", Developer = Developers.EA });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Bad,Title = "Battlefield 4", Developer = Developers.EA });

            Save(new VideoGame 
                { ID = 0,Rating= Rating.Good, Title = "Battlefield 5", Developer = Developers.EA });

        }


        public int Delete(VideoGame item)
        {
            var foundGame = _videoGameList.FirstOrDefault(i => i.ID == item.ID);

            if (foundGame == null)
            {
                return 0;
            }
            else
            {
                _videoGameList.Remove(foundGame);

                return 1;
            }
        }

        public IQueryable<VideoGame> GetIqeryAble()
        {
            var queryAble = _videoGameList.AsQueryable();
            return queryAble;
        }

        public int Save(VideoGame item)
        {
            if(item.ID == 0 && _videoGameList.Count == 0)
            {
                item.ID = 1;
                _videoGameList.Add(item);
                return 1;
            }
            else if(item.ID > 0)
            {
                var foundUpdatedGame = _videoGameList
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
                var maxNum = _videoGameList.Max(v => v.ID);
                item.ID = maxNum + 1;
                _videoGameList.Add(item);
                return 1;
            }

        }
    }
}
