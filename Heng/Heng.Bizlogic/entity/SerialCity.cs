using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.entity
{
    public class SerialCity
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string MapSize { get; set; }
        public string MaxX { get; set; }
        public string MaxY { get; set; }

        public List<SerialEntrance> Entrance { get; set; }
    }

    public class SerialEntrance
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string Condition { get; set; }
        public string PutPosition { get; set; }
        public string Type { get; set; }
        public string XRange { get; set; }
        public string YRange { get; set; }
        public string until { get; set; }
    }
}
