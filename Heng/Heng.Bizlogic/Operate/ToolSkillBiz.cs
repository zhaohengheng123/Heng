using Heng.Bizlogic.entity;
using Heng.Bizlogic.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Operate
{
    /// <summary>
    /// 针对道具/技能使用用到的中间层，尤其是check各种状态
    /// </summary>
    public class ToolSkillBiz : BaseBiz
    {

        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
        public ToolSkillBiz(int windowNum) : base(windowNum)
        {

        }


        private void MoveToConer()
        {
            WindowAPI.MMouseMoveTo(0, 0, 0);
        }

        /// <summary>
        /// 检查Dialog打开状态
        /// </summary>
        /// <param name="dialogName"></param>
        /// <returns></returns>
        public bool CheckDialogStatus(string dialogName)
        {
            //移动鼠标到边上
            MoveToConer();
            string subPic = Singleton.GetInstance().PicRootDir + "dialog\\" + dialogName + ".png";
            if (!File.Exists(subPic))
            {
                log.Error("不存在路径" + subPic);
                return false;
            }
            Bitmap bm = PicUtil.GetScreen(CenterPoint.X, CenterPoint.Y - 240, 320, 240);
            List<Point> list = PicCorFinder.FindPicture(subPic, bm, Rectangle.Empty, 2);
            //没有被找到
            if (list.Count == 0)
            {
                return false;
            }
            else
            { return true; }
        }


        /// <summary>
        /// 检查toolName是否存在
        /// </summary>
        /// <param name="toolName"></param>
        /// <returns></returns>
        public bool CheckToolsStatus(string toolName)
        {
            //移动鼠标到边上
            MoveToConer();
            string subPic = Singleton.GetInstance().PicRootDir + "tools\\" + toolName + ".png";
            if (!File.Exists(subPic))
            {
                log.Error("不存在路径" + subPic);
                return false;
            }
            Bitmap bm = PicUtil.GetScreen(CenterPoint.X + 200, CenterPoint.Y + 40, 120, 200);
            List<Point> list = PicCorFinder.FindPicture(subPic, bm, Rectangle.Empty, 2);
            //没有被找到
            if (list.Count == 0)
            {
                return false;
            }
            else
            {
                Point p1 = Singleton.GetInstance().dicWindows[WindowNum].Point;
                WindowAPI.MMouseMoveTo(0, p1.X + 540, p1.Y - 170);
                return true;
            }
        }
    }
}
