using Heng.Bizlogic.entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic
{
    //各类刷新类值的方法
    public static class SingletonHandler
    {
        /// <summary>
        /// 处理窗口
        /// </summary>
        /// <param name="num"></param>
        /// <param name="wi"></param>
        public static void AddDicWindows(int num, Window wi)
        {
            Singleton.GetInstance().dicWindows.Remove(num);
            Singleton.GetInstance().dicWindows.Add(num, wi);
        }

        public static void EditWindowActive(int num)
        {
            Singleton.GetInstance().dicWindows[num].IsActive = !Singleton.GetInstance().dicWindows[num].IsActive;
        }

        public static void EditWindowName(int num, string windowName)
        {
            Singleton.GetInstance().dicWindows[num].WindowName = windowName;
        }

        public static void EditWindowPoint(int num, Point point)
        {
            Singleton.GetInstance().dicWindows[num].Point = point;
        }
    }
}
