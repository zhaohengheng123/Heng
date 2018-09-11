using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.entity
{
    public class MapCoordinate
    {
        public string CityName { get; set; }

        public GameCoordinate coor { get; set; }


    }

    public class GameCoordinate
    {
        public GameCoordinate()
        {
          
        }
        public GameCoordinate(int x, int y) {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
