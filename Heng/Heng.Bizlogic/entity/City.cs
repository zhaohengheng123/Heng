using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.entity
{
    public class City
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public GameCoordinate MapMaxGameCoor { get; set; }
        public int[] MapSize { get; set; }
        public List<Entrance> Entrances { get; set; }
        public GameCoordinate MapCenterCoor { get => new GameCoordinate((int)MapMaxGameCoor.X / 2, (int)MapMaxGameCoor.Y / 2); }
        public double XS { get => (double)(MapSize[0] / MapMaxGameCoor.X * 1.0); }
    }

    public class Entrance
    {
        public int PutPX { get; set; }
        public int PutPY { get; set; }
        public int PutPRX { get; set; }
        public int PutPRY { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string Condition { get; set; }
        public string Type { get; set; }
        public int[] XRange { get; set; }
        public int[] YRange { get; set; }
        public string until { get; set; }
        public int SecondePutPX { get; set; }
        public int SecondePutPY { get; set; }
        public int SecondePutPRX { get; set; }
        public int SecondePutPRY { get; set; }
    }
}
