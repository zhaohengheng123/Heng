using Heng.Bizlogic.Enum;
using Heng.Bizlogic.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate
{
    public class BaseBiz
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
        public BaseBiz(int windowNum)
        {
            this.WindowNum = windowNum;
            Point p1 = Singleton.GetInstance().dicWindows[WindowNum].Point;
            AbsolutePC = new int[2] { 0, 0 };
            RelativePC = new int[2] { 0, 0 };
            //pc = new GameCommonUtil().GetPC(windowNum);
            this.CenterPoint = new Point(p1.X + 320, p1.Y - 240);
            //this.GameCenterPoint = new Point(p1.X + 320 + pc[0], p1.Y - 240 + pc[1]);
        }
        public int WindowNum { get; set; }

        public Point CenterPoint { get; set; }

        public Point GameCenterPoint { get; set; }

        /// <summary>
        /// 绝对偏差，与箭头的绝对偏差
        /// </summary>
        public int[] AbsolutePC { get; set; }

        /// <summary>
        /// 相对偏差，与上次鼠标相对的偏差值，用于鼠标移动后与异动前的偏差对比2次调整！
        /// </summary>
        public int[] RelativePC { get; set; }

        public void ResetPC()
        {
            int[] oldpc = AbsolutePC;
            int[] newpc = new GameCommonUtil().GetPC(WindowNum);
            RelativePC = new int[2] { newpc[0] - oldpc[0], newpc[1] - oldpc[1] };
            AbsolutePC = newpc;
            Point p1 = Singleton.GetInstance().dicWindows[WindowNum].Point;
            GameCenterPoint = new Point(p1.X + 320 + AbsolutePC[0], p1.Y - 240 + AbsolutePC[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pc"></param>
        public void JiaoZhunMouse(bool isAbsolute)
        {
            Point po = new Point();
            WindowAPI.GetCursorPos(out po);
            ResetPC();
            if (isAbsolute)
                WindowAPI.MMouseMove(0, AbsolutePC[0], -AbsolutePC[1]);
            else
                WindowAPI.MMouseMove(0, RelativePC[0], -RelativePC[1]);
        }

        /// <summary>
        /// 必须是静止状态才可调用
        /// </summary>
        public void MPutToPerson()
        {
            //线程休眠2秒，使得人物处于屏幕正中央！
            //TODO，需后续测试休眠时间，因为含图片计算等等耗费不少时间，所以初步预计一般2秒够了
            //移动的时候肯定不准了
            WindowAPI.MMouseMoveTo(0, CenterPoint.X, CenterPoint.Y);
            JiaoZhunMouse(true);
            Thread.Sleep(50);
        }


        
        public void ActiveWindow()
        {
            Thread.Sleep(30);
            Point p1 = Singleton.GetInstance().dicWindows[WindowNum].Point;
            //窗口快速移动
            WindowAPI.MMouseMoveTo(0, p1.X + StringUtil.GetRandomNum(320, 8), p1.Y - StringUtil.GetRandomNum(508, 2));
            WindowAPI.MMouseClick(1);
        }

        /// <summary>
        /// 屏蔽人员,毯子，F9
        /// </summary>
        public void PingBiPlayer()
        {
            WindowAPI.MKeyDownUp(0, DeviceEnum.KeyBoardEnum.F9);
            WindowAPI.MZuHeKeyDownUp(0x40, DeviceEnum.KeyBoardEnum.h);
        }
    }
}
