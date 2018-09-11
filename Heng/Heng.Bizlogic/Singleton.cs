using Heng.Bizlogic.entity;
using Heng.Bizlogic.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heng.Bizlogic
{
    public class Singleton
    {
        private static Singleton _instance = null;
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        private Singleton()
        {
            //初始化属性
            for (int i = 1; i < 6; i++)
            {
                dicWindows.Add(i, new Window() { WindowName = "尚未定位激活,请选择定位窗口！" + i });
            }
            APP_ID = ConfigurationManager.AppSettings["APP_ID"];
            API_KEY = ConfigurationManager.AppSettings["API_KEY"];
            SECRET_KEY = ConfigurationManager.AppSettings["SECRET_KEY"];
            GameBili = 20;//通过测量预估的
            PicRootDir = @"D:\gamepic\";
            WindowSize = new int[2] { Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height };
            ReadAllCityMaps();

        }

        public int[] WindowSize { get; set; }

        public Dictionary<int, Window> dicWindows = new Dictionary<int, Window>();
        public string APP_ID { get; set; }
        public string API_KEY { get; set; }
        public string SECRET_KEY { get; set; }

        public string PicRootDir { get; set; }
        public int GameBili { get; set; }

        //name对应code
        public Dictionary<string, string> dicCityCode = new Dictionary<string, string>();

        //code对应city
        public Dictionary<string, City> dicCitys = new Dictionary<string, City>();

        private void ReadAllCityMaps()
        {
            dicCityCode.Clear();
            dicCitys.Clear();
            string[] files = Directory.GetFiles(PicRootDir + "map");
            foreach (string fileName in files)
            {
                string strJson = File.ReadAllText(fileName, Encoding.GetEncoding("GB2312"));
                SerialCity c = JsonConvert.DeserializeObject<SerialCity>(strJson);
                dicCityCode.Add(c.CityName, c.CityCode);
                dicCitys.Add(c.CityCode, ToCity(c));
            }
        }


        //再做下转换兼容！！！
        private City ToCity(SerialCity city)
        {
            string[] str = city.MapSize.Split(',');
            List<Entrance> Entrances = new List<Entrance>();

            foreach (SerialEntrance item in city.Entrance)
            {
                string[] strP = item.PutPosition.Split(',');
                string[] strPX = strP[0].TrimEnd(')').Split('(');
                string[] strPY = strP[1].TrimEnd(')').Split('(');
                string[] xrange = item.XRange.Split('-');
                string[] yrange = item.YRange.Split('-');
                string[] arruntil = item.until.Split('|');
                string secondPP = arruntil[1];
                string[] str2P = secondPP.Split(',');
                string[] str2PX = str2P[0].TrimEnd(')').Split('(');
                string[] str2PY = str2P[1].TrimEnd(')').Split('(');
                string until = ""; int SecondePutPX = 0; int SecondePutPRX = 0; int SecondePutPY = 0; int SecondePutPRY = 0;
                if (arruntil.Length > 0)
                {
                    until = arruntil[0];
                    SecondePutPX = Convert.ToInt32(str2PX[0]);
                    SecondePutPRX = str2PX.Length == 2 ? Convert.ToInt32(str2PX[1]) : 0;
                    SecondePutPY = Convert.ToInt32(str2PY[0]);
                    SecondePutPRY = str2PY.Length == 2 ? Convert.ToInt32(str2PY[1]) : 0;
                }
                Entrances.Add(new Entrance()
                {

                    PutPX = Convert.ToInt32(strPX[0]),
                    PutPRX = strPX.Length == 2 ? Convert.ToInt32(strPX[1]) : 0,
                    PutPY = Convert.ToInt32(strPY[0]),
                    PutPRY = strPY.Length == 2 ? Convert.ToInt32(strPY[1]) : 0,
                    CityCode = item.CityCode,
                    CityName = item.CityName,
                    Condition = item.Condition,
                    Type = String.IsNullOrEmpty(item.Type) ? "Walk" : item.Type,
                    XRange = new int[] { Convert.ToInt32(xrange[0]), Convert.ToInt32(xrange[1]) },
                    YRange = new int[] { Convert.ToInt32(yrange[0]), Convert.ToInt32(yrange[1]) },
                    until = until,
                    SecondePutPX = SecondePutPX,
                    SecondePutPRX = SecondePutPRX,
                    SecondePutPY = SecondePutPY,
                    SecondePutPRY = SecondePutPRY
                });
            }
            City city2 = new City()
            {
                CityCode = city.CityCode,
                CityName = city.CityName,
                MapMaxGameCoor = new GameCoordinate() { X = Convert.ToInt32(city.MaxX), Y = Convert.ToInt32(city.MaxY) },
                MapSize = new int[2] { Convert.ToInt32(str[0]), Convert.ToInt32(str[1]) },
                Entrances = Entrances
            };
            return city2;
        }


    }
}
