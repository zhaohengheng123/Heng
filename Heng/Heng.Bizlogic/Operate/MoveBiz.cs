using Heng.Bizlogic.entity;
using Heng.Bizlogic.Exceptions;
using Heng.Bizlogic.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate
{
    /// <summary>
    /// 鼠标/人物移动的相关中间层类，对基础通用方法util的进一步封装
    /// </summary>
    public class MoveBiz : BaseBiz
    {

        public MoveBiz(int windowNum) : base(windowNum)
        {

        }

        #region old方法
        ///// <summary>
        ///// 过时方法
        ///// </summary>
        ///// <param name="listgc"></param>
        ///// <returns></returns>
        //[Obsolete]
        //private bool CheckJiaoZhunStatus(List<GameCoordinate> listgc)
        //{
        //    GameCoordinate gc_3 = new GameCoordinate();
        //    GameCoordinate gc_2 = new GameCoordinate();
        //    int resize = 11;
        //    if (listgc.Count > 2)
        //    {
        //        if (listgc.Count == 4)
        //        {
        //            resize = 3;
        //        }
        //        else
        //        {
        //            resize = 6;
        //        }
        //        //取得最近的2次
        //        gc_3 = listgc[listgc.Count - 1];
        //        gc_2 = listgc[listgc.Count - 2];
        //        GameCoordinate gc_1 = listgc[listgc.Count - 3];
        //        if (gc_3.X == gc_2.X && gc_3.Y == gc_2.Y)
        //        {
        //            if (gc_1.X == gc_2.X && gc_1.Y == gc_2.Y)
        //            {
        //                //都没动的话很有问题了,肯定到了什么阻挡物了，比如一些特别的东西，阻止掉继续矫正的势头！
        //                return true;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        gc_3 = listgc[listgc.Count - 1];
        //        gc_2 = listgc[listgc.Count - 2];
        //    }
        //    //比较gc3,gc2,坐标差太大了，肯定不是平路了，所以去搞他一下
        //    if (Math.Abs(gc_3.X - gc_2.X) > 3 || Math.Abs(gc_3.Y - gc_2.Y) > 3)
        //    {
        //        return true;
        //    }
        //    #region 正规校验开始
        //    bool xok = false;
        //    bool yok = false;
        //    //等于0，鼠标过于靠左
        //    if (gc_3.X - gc_2.X == 1)
        //    {
        //        //x轴无问题的！
        //        xok = true;
        //    }
        //    else
        //    {
        //        this.CenterPoint = new Point(this.CenterPoint.X - resize * (gc_3.X - (gc_2.X + 1)), this.CenterPoint.Y);
        //    }
        //    if (gc_3.Y - gc_2.Y == 1)
        //    {
        //        //y轴无问题的！
        //        yok = true;
        //    }
        //    else
        //    {
        //        this.CenterPoint = new Point(this.CenterPoint.X, this.CenterPoint.Y + resize * (gc_3.Y - (gc_2.Y + 1)));
        //    }
        //    if (xok && yok)
        //    {
        //        return true;
        //    }
        //    return false;
        //    #endregion
        //}

        ///// <summary>
        ///// 校准位置，走一步截图，测试下
        ///// </summary>
        //[Obsolete]
        //public bool JiaoZhunPosition()
        //{
        //    List<GameCoordinate> listgc = new List<GameCoordinate>();
        //    GameCoordinate gc = GetNowMap().coor;
        //    listgc.Add(gc);
        //    bool flag = false;
        //    //最多进行3次校正，递归有点疯狂的
        //    for (int i = 0; i < 4; i++)
        //    {
        //        MMoveRealCoor(1, 1);
        //        GameCoordinate gc2 = GetNowMap().coor;
        //        listgc.Add(gc2);
        //        //比较gc和gc2
        //        flag = CheckJiaoZhunStatus(listgc);
        //        if (flag)
        //        {
        //            break;
        //        }
        //    }
        //    return flag;
        //}

        #endregion



        /// <summary>
        /// 做了一堆容错，相对稳定了，获取目前所在区域
        /// 确认，必须在开始调用的！dialog打开前！！
        /// </summary>
        /// <returns></returns>
        public MapCoordinate GetNowMap()
        {
            WindowAPI.MMouseMoveTo(0, 0, 0);//移开防止挡住地图视线
            string zuobiao = "";
            while (true)
            {
                //获取当前窗口
                Point point = Singleton.GetInstance().dicWindows[WindowNum].Point;
                Bitmap bm = PicUtil.GetScreen(point.X + 15, point.Y - 454, 120, 16);
                //百度人工智能有一定错误率，主要95%集中在了,所以这边只要有,就放大图片重新识别，直到ok
                for (int i = 6; i < 15; i++)
                {
                    Bitmap bm2 = PicUtil.PicSized(bm, i);
                    JObject j = PicUtil.BaiDuOCR(bm2);
                    bm2.Dispose();
                    zuobiao = j["words_result"][0]["words"].ToString();
                    if (zuobiao.Contains(","))
                    {
                        break;
                    }
                    else
                    {
                        #region ,不容易被识别，做了一堆容错
                        string zuobiaocoor = zuobiao.Split('[')[1].Trim(']').Trim();
                        //2位的，肯定中间是,
                        if (zuobiaocoor.Length == 2)
                        {
                            zuobiaocoor = zuobiaocoor.Substring(0, 1) + "," + zuobiaocoor.Substring(1, 1);
                        }
                        else if (zuobiaocoor.Length == 3)
                        {
                            continue;
                        }
                        else if (zuobiaocoor.Length == 4)
                        {
                            //,如果在第二个，则第二位不应  如果是6766
                            if (Convert.ToInt32(zuobiaocoor.Substring(1, 1)) > 3)//则绝不可能分在第1个
                            {
                                //考虑分第3个，
                                if (Convert.ToInt32(zuobiaocoor.Substring(0, 1)) > 5)//绝不可能大于5
                                {
                                    zuobiaocoor = zuobiaocoor.Substring(0, 2) + "," + zuobiaocoor.Substring(2, 2);
                                }
                            }
                        }
                        else if (zuobiaocoor.Length == 5)//绝对是从第二个分
                        {
                            if (Convert.ToInt32(zuobiaocoor.Substring(2, 1)) > 3)//如果大于3，肯定分
                            {
                                if (Convert.ToInt32(zuobiaocoor.Substring(0, 1)) <= 5)
                                {
                                    zuobiaocoor = zuobiaocoor.Substring(0, 3) + "," + zuobiaocoor.Substring(3, 2);
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(zuobiaocoor.Substring(0, 1)) > 5)
                                {

                                    zuobiaocoor = zuobiaocoor.Substring(0, 2) + "," + zuobiaocoor.Substring(2, 3);
                                }
                            }
                        }
                        else
                        {
                            zuobiaocoor = zuobiaocoor.Substring(0, 3) + "," + zuobiaocoor.Substring(3, 3);
                        }
                        #endregion
                        if (!StringUtil.IsNumber(zuobiaocoor.Replace(",", "")))
                        {
                            continue;
                        }
                        zuobiao = zuobiao.Split('[')[0] + "[" + zuobiaocoor + "]";
                    }
                }
                if (!zuobiao.Contains(","))
                {
                    //TODO，关闭所有栏目，确认，必须在开始调用的！
                    MMoveRealCoor(2, 2);//随便走个几步
                    WindowAPI.MMouseClick(1);
                    bm.Dispose();
                }
                else
                {
                    bm.Dispose();
                    break;
                }
            }
            return StringUtil.AnalyzeMapStr(zuobiao);
        }

        #region 鼠标放置到指定位置！！


        /// <summary>
        ///人物请保持静止！！！往指定方向走一走，有1-2的误差！
        /// </summary>
        public void MMoveRealCoor(int x, int y)
        {
            ActiveWindow();
            //先放到指定位置
            MPutToPerson();
            log.Info("防止正中央");
            new GameCommonUtil().ThreadRest(2);
            PingBiPlayer();
            //初始化目标地址
            WindowAPI.MMouseMove(0, Singleton.GetInstance().GameBili * x, -y * Singleton.GetInstance().GameBili);
            //校准偏差
            JiaoZhunMouse(false);
        }

        public void MMoveToRealCoor(int x, int y)
        {
            new GameCommonUtil().ThreadRest(2);
            PingBiPlayer();
            //初始化目标地址
            WindowAPI.MMouseMoveTo(0, CenterPoint.X + Singleton.GetInstance().GameBili * x, CenterPoint.Y + y * Singleton.GetInstance().GameBili);
            //校准偏差
            JiaoZhunMouse(true);
        }


        #region 地图移动选点移动，误差最后再3以内在退出

        /// <summary>
        /// 放到地图指定坐标TODO,少了个系数！！！
        /// </summary>
        /// <param name="randomXS"></param>
        private Point MPutToMayMapCenter(City city, GameCoordinate targetGc)
        {
            //20为误差阈值，其实阈值15已经很高了，不会超过20的！
            //计算预估坐标
            //TODO  15这个觉得没什么大问题，测试多次能正确放置
            int numX = (int)(city.MapMaxGameCoor.X / 15);
            int numY = (int)(city.MapMaxGameCoor.Y / 15);
            int x = 0; int y = 0;
            //如果4个点均是在内切20px范围的，直接转移进入
            if (targetGc.X > numX && (Math.Abs(city.MapMaxGameCoor.X - targetGc.X) > numX))
            {
                x = (int)((targetGc.X - city.MapCenterCoor.X) * city.XS) + CenterPoint.X;
            }
            else
            {
                if (targetGc.X <= numX)
                {
                    x = (int)((targetGc.X - city.MapCenterCoor.X) * city.XS) + CenterPoint.X + (int)((numX - targetGc.X) * city.XS);
                }
                else
                {
                    x = (int)((targetGc.X - city.MapCenterCoor.X) * city.XS) + CenterPoint.X - (int)((numX - city.MapMaxGameCoor.X + targetGc.X) * city.XS);
                }
            }


            if (targetGc.Y > numY && (Math.Abs(city.MapMaxGameCoor.Y - targetGc.Y) > numY))
            {
                y = CenterPoint.Y - (int)((targetGc.Y - city.MapCenterCoor.Y) * city.XS);
            }
            else
            {
                if (targetGc.Y <= numY)
                {
                    y = CenterPoint.Y - (int)((targetGc.Y - city.MapCenterCoor.Y) * city.XS) - (int)((numY - targetGc.Y) * city.XS);
                }
                else
                {
                    y = CenterPoint.Y - (int)((targetGc.Y - city.MapCenterCoor.Y) * city.XS) + (int)((numY - city.MapMaxGameCoor.Y + targetGc.Y) * city.XS);
                }
            }
            //mayPoint = new Point(CenterPoint.X + targetGc.X - city.MapCenterCoor.X, city.MapCenterCoor.Y - targetGc.Y + CenterPoint.Y);
            WindowAPI.MMouseMoveTo(0, x, y);
            Thread.Sleep(100);
            return new Point(x, y);
        }


        /// <summary>
        /// 放到地图指定坐标,
        /// </summary>
        /// <param name="randomXS"></param>
        public void MPutToMapCoor(GameCoordinate targetGc, bool NeedGoThere)
        {
            Point po_nowdeskzuobiao = new Point();
            string cityName = GetNowMap().CityName;
            City city = new City() { CityName = cityName, MapMaxGameCoor = new GameCoordinate(191, 119), MapSize = new int[2] { 441, 276 } };
            po_nowdeskzuobiao = MPutToMayMapCenter(city, targetGc);
            if (NeedGoThere)
                WindowAPI.MMouseClick(1);
            try
            {
                MPutToMap(city, targetGc, NeedGoThere);
            }
            catch (HengTimeOutException ex)
            {
                if (ex.GetError() == "restart")
                    MPutToMapCoor(targetGc, NeedGoThere);//todo思考问题是否有 
            }
        }


        /// <summary>
        /// 做了一堆容错，百度坑爹爹爹，相对稳定了
        /// </summary>
        /// <returns></returns>
        private void MPutToMap(City city, GameCoordinate targetGC_JQ, bool NeedGoThere)
        {
            try
            {
                Point po_nowdeskzuobiao = new Point();
                WindowAPI.GetCursorPos(out po_nowdeskzuobiao);
                //获取当前的游戏坐标
                GameCoordinate nowGameCoor = MapOcr(city, targetGC_JQ);
                int x = targetGC_JQ.X - nowGameCoor.X;//要移动的距离
                int y = targetGC_JQ.Y - nowGameCoor.Y;//要移动的距离
                                                      //获取到理想的地址
                Point po_targetwdeskzuobiao = new Point((int)(po_nowdeskzuobiao.X + x * city.XS), (int)(po_nowdeskzuobiao.Y - y * city.XS));
                //前往该地址
                WindowAPI.MMouseMoveTo(0, po_targetwdeskzuobiao.X, po_targetwdeskzuobiao.Y);
                if (NeedGoThere)
                    WindowAPI.MMouseClick(1);
                new GameCommonUtil().ThreadRest(2);
                //------------------
                //截图
                nowGameCoor = MapOcr(city, targetGC_JQ);
                if (nowGameCoor.X == -1)
                {
                    Console.WriteLine("没颜色,重新来");
                    throw new HengTimeOutException("没颜色,重新来");
                }
                if (Math.Abs(nowGameCoor.X - targetGC_JQ.X) < 3 && Math.Abs(nowGameCoor.Y - targetGC_JQ.Y) < 3)
                {
                    Console.WriteLine("跳出");
                    return;
                }
                Console.WriteLine("进入循环 x:：" + Math.Abs(nowGameCoor.X - targetGC_JQ.X) + "y：" + Math.Abs(nowGameCoor.Y - targetGC_JQ.Y));
                //递归该方法
                MPutToMap(city, targetGC_JQ, NeedGoThere);
            }
            catch (HengTimeOutException ex)
            {
                throw new HengTimeOutException(ex.GetError());
            }
        }

        /// <summary>
        /// 根据桌面坐标获取返回当前坐标
        /// </summary>
        /// <param name="po"></param>
        /// <returns></returns>
        public GameCoordinate MapOcr(City city, GameCoordinate targetGC_JQ)
        {

            string words = "";
            int isize = 3;
            string[] strWords = { "0", "0" };
            GameCoordinate nowgc = new GameCoordinate(0, 0);
            int times = 0;
            while (true)
            {
                if (times > 10)
                {
                    throw new HengTimeOutException("restart");
                }
                Point po_nowdeskzuobiao = new Point();
                WindowAPI.GetCursorPos(out po_nowdeskzuobiao);
                if (isize < 8)
                    isize++;
                try
                {
                    new GameCommonUtil().ThreadRest(2);
                    //获取到键盘的，然后截图大约是x-60 y-40 大小是120,80
                    Bitmap bm = PicUtil.GetScreen(po_nowdeskzuobiao.X - 50, po_nowdeskzuobiao.Y - 50, 100, 80);
                    // 处理坐标图像
                    // 1、截图
                    // 2、分析点图，黄色图片，减少变换量
                    // 3、颜色反转
                    // 4、放大图片
                    List<Point> lisp = PicCorFinder.FindColor(bm, "#FFFF00", Rectangle.Empty, 0);
                    if (lisp.Count == 0)
                    {
                        bm.Dispose();
                        return new GameCoordinate(-1, -1);
                    }
                    bm = PicUtil.CaptureImage(bm, new Point(lisp[0].X - 10, lisp[0].Y - 8), 60, 25);
                    bm = PicUtil.ChangeColor(bm, Color.FromArgb(255, 255, 0));
                    //百度人工智能有一定错误率，主要95%集中在了,所以这边只要有,就放大图片重新识别，直到ok
                    Bitmap bm2 = PicUtil.PicSized(bm, isize);
                    JObject jobject = PicUtil.BaiDuOCR(bm2);
                    JArray jarr = (JArray)jobject["words_result"];
                    //如果超出边界，移动移出来
                    if (jarr.Count == 0)
                    {
                        DoMove(targetGC_JQ);
                        bm2.Dispose();
                        bm.Dispose();
                        continue;
                    }
                    bm.Dispose();
                    bm2.Dispose();
                    bool flag = false;
                    for (int i = 0; i < jarr.Count; i++)
                    {
                        words = jarr[i]["words"].ToString();
                        flag = StringUtil.IsNumber(words.Replace(",", ""));
                        if (flag)
                        {
                            break;
                        }
                    }
                    Console.WriteLine("words：" + words);
                    if (!words.Contains(',') || !flag)
                    {
                        //大概率没识别出来，就动下鼠标
                        Move11Step(city, targetGC_JQ, ref times);
                        continue;
                    }
                    strWords = words.Split(',');
                    nowgc = new GameCoordinate(Convert.ToInt32(strWords[0]), Convert.ToInt32(strWords[1]));
                    //if (IsErrorRange(nowgc, targetGC_JQ, isize))
                    //{
                    //    //大概率没识别出来，就动下鼠标
                    //    Move11Step(city, targetGC_JQ, ref times);
                    //    continue;
                    //}
                    break;
                }
                catch (Exception)
                {
                    //大概率没识别出来，就动下鼠标
                    Move11Step(city, targetGC_JQ, ref times);
                    continue;
                }
            }
            return nowgc;
        }
        /// <summary>
        /// 与实际值超过40就异常的
        /// </summary>
        /// <param name="city"></param>
        /// <param name="po_nowdeskzuobiao"></param>
        /// <param name=""></param>
        public bool IsErrorRange(GameCoordinate result, GameCoordinate targetGC_JQ, int time)
        {
            //超过20就异常
            int WuCha = 0;
            switch (time)
            {
                case 1:
                    WuCha = 890;
                    break;
                case 2:
                case 3:
                    WuCha = 40;
                    break;
                case 4:
                case 5:
                    WuCha = 40;
                    break;
                default:
                    WuCha = 40;
                    break;
            }

            if (Math.Abs(targetGC_JQ.X - result.X) > WuCha || Math.Abs(targetGC_JQ.Y - result.Y) > WuCha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// move方法，每次move下，1格格move回
        /// </summary>
        /// <param name="city"></param>
        /// <param name="targetGC_JQ"></param>
        public void Move11Step(City city, GameCoordinate targetGC_JQ, ref int times)
        {
            //看下目标点的落点，理论落点
            if (targetGC_JQ.X > city.MapCenterCoor.X && targetGC_JQ.Y > city.MapCenterCoor.Y)
            {
                //第一象限,看下与最大值的哪个差的多，做左下方移动
                if (Math.Abs(city.MapMaxGameCoor.X - targetGC_JQ.X) < Math.Abs(city.MapMaxGameCoor.Y - targetGC_JQ.Y))
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, -2, 0);
                    times++;
                    if (times > 5)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, 0, -2);
                        times++;
                    }
                }
                else
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, 0, -2);
                    times++;
                    if (times > 30)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, -2, 0);
                        times++;
                    }
                }

            }
            else if (targetGC_JQ.X <= city.MapCenterCoor.X && targetGC_JQ.Y > city.MapCenterCoor.Y)
            {
                //第二象限
                //第一象限,看下与最大值的哪个差的多，做左下方移动
                if (Math.Abs(targetGC_JQ.X - 0) < Math.Abs(city.MapMaxGameCoor.Y - targetGC_JQ.Y))
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, 2, 0);
                    times++;
                    if (times > 30)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, 0, -2);
                        times++;
                    }
                }
                else
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, 0, -2);
                    times++;
                    if (times > 30)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, 2, 0);

                        times++;
                    }
                }
            }
            else if (targetGC_JQ.X <= city.MapCenterCoor.X && targetGC_JQ.Y <= city.MapCenterCoor.Y)
            {
                //第三象限右上
                if (Math.Abs(targetGC_JQ.X - 0) < Math.Abs(city.MapMaxGameCoor.Y - 0))
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, 2, 0);
                    times++;
                    if (times > 30)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, 0, 2);
                        times++;
                    }
                }
                else
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, 0, 2);
                    times++;
                    if (times > 30)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, 2, 0);
                        times++;
                    }
                }

            }
            else
            {
                //第4象限坐上
                if (Math.Abs(city.MapMaxGameCoor.X - targetGC_JQ.X) < Math.Abs(city.MapMaxGameCoor.Y - 0))
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, -2, 0);
                    times++;
                    if (times > 30)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, 0, 2);
                        times++;
                    }
                }
                else
                {
                    //大概率y轴方向，则延y轴移动2格子，移动
                    WindowAPI.MMouseMove(0, 0, 2);
                    times++;
                    if (times > 30)
                    {
                        //大概率y轴方向，则延y轴移动2格子，移动
                        WindowAPI.MMouseMove(0, -2, 0);
                        times++;
                    }

                }

            }
        }


        /// <summary>
        /// 如出现在边界外，获取该值的目标坐标并且返回可能的实际坐标值
        /// </summary>
        /// <param name="po"></param>
        /// <param name="wantpo"></param>
        /// <param name="realpo"></param>
        /// <returns></returns>
        private void DoMove(GameCoordinate wantpo)
        {
            //确定移动的方向
            int[] arr = { 0, 0 };
            if (wantpo.X > (int)(548 / 2))//x轴方向
                arr[0] = 1;//右移动
            else if (wantpo.X < (int)(548 / 2))
                arr[0] = -1;//左移动
            else
                arr[0] = 0;//不移动

            if (wantpo.Y > (int)(278 / 2))//y轴方向
                arr[1] = 1;//上移动
            else if (wantpo.Y < (int)(278 / 2))
                arr[1] = -1;//下移动
            else
                arr[1] = 0;//不移动


            //推测4个象限的落点可能性
            //TODO（是否需要判断多次），x轴右边的，则给他目标值偏差30px
            int x = 0;
            if (arr[0] > 0)
            {
                //TODO(548和1)，对应地图移动距离
                x = (548 - wantpo.X) * 1 - 30 * 1;
            }
            if (arr[0] < 0)
            {
                x = 30 * 1 - wantpo.X * 1;
            }

            int y = 0;
            if (arr[1] > 0)
            {
                //TODO(278和1)，对应地图移动距离
                y = -1 * ((278 - wantpo.Y) * 1 - 30 * 1);
            }
            if (arr[1] < 0)
            {
                x = -1 * (30 * 1 - wantpo.Y * 1);
            }
            //移动
            WindowAPI.MMouseMove(0, x, y);
        }
        #endregion

        #endregion

        /// <summary>
        /// 鼠标放到NPC上面
        /// </summary>
        /// <param name="gc"></param>
        /// <returns></returns>
        public bool PointPutToGameCoor(GameCoordinate targetGC)
        {
            //直接获取中心点坐标做偏移量

            GameCoordinate nowGC = GetNowMap().coor;
            int x = targetGC.X - nowGC.X;
            int y = targetGC.Y - nowGC.Y;
            //已经在该坐标的话返回
            if (x == 0 && y == 0)
            {
                return true;
            }
            if (Math.Abs(x) < 10 && Math.Abs(y) < 10)
            {
                MMoveToRealCoor(x, -y);
            }
            return true;
        }


        public void PutToPosition(int x, int y, int rx, int ry)
        {
            new GameCommonUtil().PutToPosition(WindowNum, x, y, rx, ry);
        }

        /// <summary>
        /// 获取所需用时
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public int GetWalkSeconds(string cityName)
        {
            WindowAPI.MMouseMoveTo(0, 0, 0);
            Point p1 = Singleton.GetInstance().dicWindows[WindowNum].Point;
            Bitmap bm = PicUtil.GetScreen(p1.X, p1.Y - 480, 640, 480);
            //数点的个数,100px与等于15秒，ZZ100px约等于10点，1个点的时间2.3倍
            //平均每个点为3.5/XS
            City city = new City()
            {
                CityName = cityName,
                MapMaxGameCoor = new GameCoordinate(191, 119),
                MapSize = new int[2] { 441, 276 }
            };
            List<Point> list = PicCorFinder.FindPicture(Singleton.GetInstance().PicRootDir + "wp.png", bm, Rectangle.Empty, 2, 0.9, true);
            //额外加出3个点，防止几类情况 1、最后个棋子的挡住1个+自己一个2、大红点挡住一个
            return (int)((list.Count + 3) * 3.5 / city.XS);
        }
    }
}
