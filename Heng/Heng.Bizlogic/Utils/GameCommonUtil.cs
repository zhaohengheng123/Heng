using Heng.Bizlogic.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Utils
{
    public class GameCommonUtil
    {
        public readonly log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
        /// <summary>
        /// 随机档位
        /// 1档：30-60ms
        /// 2档：100-300
        /// 3档：600-1000
        /// 4档：1500-2000
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public void ThreadRest(int level)
        {
            Random random = new Random();
            switch (level)
            {
                case 1:
                    Thread.Sleep(random.Next(30, 60));
                    break;
                case 2:
                    Thread.Sleep(random.Next(100, 300));
                    break;
                case 3:
                    Thread.Sleep(random.Next(600, 1000));
                    break;
                case 4:
                    Thread.Sleep(random.Next(1500, 2000));
                    break;
                default:
                    Thread.Sleep(random.Next(1500, 2000));
                    break;
            }

        }

        //TODO,实际屏幕坐标和地图坐标的呼唤
        //思路：1、鼠标移到正中央→查看坐标→互转
        public GameCoordinate ParseToGameCoor()
        {
            //缩放比例1:20
            return null;
        }


        public Point GetGameCursorPosition(int windowNum)
        {
            Point p1 = Singleton.GetInstance().dicWindows[windowNum].Point;
            Bitmap bm = PicUtil.GetScreen(p1.X, p1.Y - 480, 640, 480);
            List<Point> listp = PicCorFinder.FindPicture(Singleton.GetInstance().PicRootDir + "ms.png", bm, Rectangle.Empty, 0);
            bm.Dispose();
            if (listp.Count == 0)
            {
                return new Point(0, 0);
            }
            else
            {
                return listp[0];
            }
        }
        public Point GetWinRandomPoint()
        {
            Random ra = new Random();
            int rx = ra.Next(0, Singleton.GetInstance().WindowSize[0]);
            int ry = ra.Next(0, Singleton.GetInstance().WindowSize[1]);

            return new Point(rx, ry);
        }

        public void PutToPosition(int windowNum, int plusX, int minusY, int randomX, int randomY)
        {
            Random ra = new Random();
            int rx = ra.Next(-1 * randomX, randomX);
            int ry = ra.Next(-1 * randomY, randomY);
            Point p = Singleton.GetInstance().dicWindows[windowNum].Point;
            Point liLunP = new Point(p.X + plusX, p.Y - minusY);
            //Console.WriteLine("理论点位" + liLunP.X + "," +liLunP.Y);
            WindowAPI.MMouseMoveTo(0, liLunP.X, liLunP.Y);
            Point p1 = new Point(liLunP.X - 75, liLunP.Y - 75);
            Thread.Sleep(100);
            Bitmap bm = PicUtil.GetScreen(p1.X, p1.Y, 150, 150);
            //bm.Save("D://pic/" + a + ".png");
            List<Point> listp = PicCorFinder.FindPicture(Singleton.GetInstance().PicRootDir + "ms.png", bm, Rectangle.Empty, 0, 0.6);
            bm.Dispose();
            if (listp.Count == 0)
            {
                Console.WriteLine("查找失败");
                Point rp = GetWinRandomPoint();
                WindowAPI.MMouseMoveTo(0, rp.X, rp.Y);
                PutToPosition(windowNum, plusX, minusY, randomX, randomY);
            }
            else
            {
                int min = 10000;
                int pcx1 = 0;
                int pcy1 = 0;
                for (int i = 0; i < listp.Count; i++)
                {
                    //找到点位
                    int pcx = 75 - (listp[i].X - 20);
                    int pcy = 75 - (listp[i].Y - 20);
                    if (pcx + pcy <= min)
                    {
                        min = pcx + pcy;
                        pcx1 = pcx;
                        pcy1 = pcy;
                    }
                    if (i > 0)
                    {
                        Console.WriteLine("找到记录2次++");
                    }
                }
                Point RealP = new Point(liLunP.X + pcx1 + rx, liLunP.Y + pcy1 + ry);
                WindowAPI.MMouseMoveTo(0, RealP.X, RealP.Y);
            }
        }

        /// <summary>
        /// 获取偏差值，最终都可以用加这个偏差，到一个精准位置，进入每个地图要重新计算偏差
        /// </summary>
        /// <param name="windowNum"></param>
        /// <returns></returns>
        public int[] GetPC(int windowNum)
        {
            Point p = Singleton.GetInstance().dicWindows[windowNum].Point;
            Point liLunP = new Point();
            WindowAPI.GetCursorPos(out liLunP);
            //Console.WriteLine("理论点位" + liLunP.X + "," +liLunP.Y);
            WindowAPI.MMouseMoveTo(0, liLunP.X, liLunP.Y);
            Point p1 = new Point(liLunP.X - 75, liLunP.Y - 75);
            Thread.Sleep(100);
            Bitmap bm = PicUtil.GetScreen(p1.X, p1.Y, 150, 150);
            List<Point> listp = new List<Point>();
            try
            {
                listp = PicCorFinder.FindPicture(Singleton.GetInstance().PicRootDir + "ms.png", bm, Rectangle.Empty, 0, 0.6);
                if (listp.Count == 0)
                    listp = PicCorFinder.FindPicture(Singleton.GetInstance().PicRootDir + "ms2.png", bm, Rectangle.Empty, 0, 0.6);
            }
            catch (Exception ex)
            {
                log.Error("解析偏差时图片解析错误:" + DateTime.Now.ToString("yyyyMMddHHmmss") + ex);
                bm.Save(Singleton.GetInstance().PicRootDir + "ErrorPic/GetPC/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png");
                return GetPC(windowNum);
            }
            bm.Dispose();
            if (listp.Count == 0)
            {
                Console.WriteLine("查找失败");
                return GetPC(windowNum);
            }
            else
            {
                int min = 10000;
                int pcx1 = 0;
                int pcy1 = 0;
                for (int i = 0; i < listp.Count; i++)
                {
                    //找到点位
                    int pcx = 75 - (listp[i].X - 20);
                    int pcy = 75 - (listp[i].Y - 20);
                    if (pcx + pcy <= min)
                    {
                        min = pcx + pcy;
                        pcx1 = pcx;
                        pcy1 = pcy;
                    }
                    if (i > 0)
                    {
                        Console.WriteLine("找到记录2次++");
                    }
                }
                return new int[2] { pcx1, pcy1 };
            }
        }


        public bool CheckIsCloseToNPC(MapCoordinate coor1, MapCoordinate coor2)
        {
            //WindowAPI.MMouseMoveTo(0, 0, 0);
            if (coor1.CityName != coor2.CityName)
            {
                return false;
            }
            if (Math.Abs(coor1.coor.X - coor2.coor.X) > 5 || Math.Abs(coor1.coor.Y - coor2.coor.Y) > 5)
            {
                return false;
            }
            return true;
        }

        public Bitmap GetFullScreen(int WindowNum)
        {
            WindowAPI.MMouseMoveTo(0, 0, 0);
            Point point = Singleton.GetInstance().dicWindows[WindowNum].Point;
            Bitmap bm = PicUtil.GetScreen(point.X, point.Y - 480, 640, 480);
            return bm;
        }

        /// <summary>
        /// 是否dialog已经打开，任意dialog
        /// </summary>
        /// <returns></returns>
        public bool HasDialogExist(int WindowNum, out Point po)
        {
            WindowAPI.MMouseMoveTo(0, 0, 0);
            po = new Point(0, 0);
            Point point = Singleton.GetInstance().dicWindows[WindowNum].Point;
            Bitmap bm = PicUtil.GetScreen(point.X, point.Y - 480, 640, 480);
            string subPic = Singleton.GetInstance().PicRootDir + "dialog\\对话框.png";
            string subPic2 = Singleton.GetInstance().PicRootDir + "dialog\\对话框2.png";
            List<string> listsubPic2 = new List<string>();
            listsubPic2.Add(subPic);
            listsubPic2.Add(subPic2);
            for (int i = 0; i < listsubPic2.Count; i++)
            {
                List<Point> listPo = PicCorFinder.FindPicture(subPic, bm, Rectangle.Empty, 10);
                if (listPo.Count > 0)
                {
                    po = listPo[0];
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// TODO，完善 1、直接关闭，2、右击关闭，3、都无效的发送socket！
        /// </summary>
        public void CloseDialogIfExist(int WindowNum)
        {
            Point po = new Point();
            if (HasDialogExist(WindowNum, out po))
            {
                new GameCommonUtil().PutToPosition(WindowNum, po.X, 480 - po.Y, 0, 0);
                new GameCommonUtil().ThreadRest(2);
                WindowAPI.MMouseClick(1);
            }
        }


       



    }
}
