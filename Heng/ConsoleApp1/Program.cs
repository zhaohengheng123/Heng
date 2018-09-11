using Heng.Bizlogic.entity;
using Heng.Bizlogic.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class Program
    {
        private static void ReadAllCityMaps()
        {
            string PicRootDir = @"D:\gamepic\";
            string[] files = Directory.GetFiles(PicRootDir + "map");
            foreach (string fileName in files)
            {
                string strJson = File.ReadAllText(fileName, Encoding.GetEncoding("GB2312"));
                SerialCity C = JsonConvert.DeserializeObject<SerialCity>(strJson);
            }
        }

        static void Main(string[] args)
        {
            //   ReadAllCityMaps();
            string[] str = "".Split('|');
            Console.WriteLine(str.Length);
            Console.ReadKey();


            //SerialCity city = new SerialCity()
            //{
            //    CityCode = "AA",
            //    CityName = "AA",
            //    MapSize = "123",
            //    MaxX = "123",
            //    MaxY = "123",
            //    Entrance = new List<SerialEntrance>()
            //    {
            //        new SerialEntrance(){
            //            CityCode="123",
            //            CityName="123",
            //            Condition="123",
            //            PutPosition="123"
            //        }
            //    }
            //};


            //string aa= JsonConvert.SerializeObject(city);
            //Console.WriteLine(aa);
          

        }

        
    }
}
