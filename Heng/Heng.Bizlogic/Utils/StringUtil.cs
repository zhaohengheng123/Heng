using Heng.Bizlogic.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Utils
{

    public static class StringUtil
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
        /// <summary>
        /// 获取窗口缩写
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GetShortWindowName(string title)
        {
            if (title.Contains("("))
            {
                title = title.Substring(title.IndexOf("(") + 1, title.IndexOf(")") - title.IndexOf("(")).Replace(" ", "");
                title = title.Substring(0, title.LastIndexOf("["));
            }
            return title;
        }


        /// <summary>
        /// asc转字符串
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string Chr(int asciiCode)
        {
            if (asciiCode >= 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                throw new Exception("ASCII Code is not valid.");
            }
        }


        public static MapCoordinate AnalyzeMapStr(string zuobiao)
        {
            string[] strzuobiao;
            string strX = "0";
            string strY = "0";
            try
            {
                strzuobiao = zuobiao.Split('[');
                string[] strcoor = strzuobiao[1].Split(',');
                strX = strcoor[0].Trim();
                strY = strcoor[1].Trim(']').Trim();
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString());
                throw;
            }
            return new MapCoordinate() { CityName = strzuobiao[0], coor = new GameCoordinate() { X = Convert.ToInt32(strX), Y = Convert.ToInt32(strY) } };
        }

        //获取随机范围
        public static int GetRandomNum(int originNum, int randomNext)
        {
            Random ra = new Random();
            int num = ra.Next(-1 * randomNext, randomNext);
            return originNum + num;
        }

        public static bool IsNumber(string strCoor)
        {
            Regex regex = new Regex("^[0-9]*$", RegexOptions.IgnoreCase);
            return regex.IsMatch(strCoor);
        }
    }
}
