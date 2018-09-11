using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Utils
{
    public class WindowAPI
    {
        [DllImport("KeyCall.dll", EntryPoint = "GetKeyDev", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MGetKeyDev();
        [DllImport("KeyCall.dll", EntryPoint = "KeySendChar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeySendChar(string AData);
        [DllImport("KeyCall.dll", EntryPoint = "MouseDown", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MouseDown(byte AKey);
        [DllImport("KeyCall.dll", EntryPoint = "MouseMove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MouseMove(byte AKey, int x, int y);
        [DllImport("KeyCall.dll", EntryPoint = "MouseMoveTo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MouseMoveTo(byte AKey, int x, int y);
        [DllImport("KeyCall.dll", EntryPoint = "MouseMoveToEx", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MouseMoveToEx(byte AKey, int x, int y);
        [DllImport("KeyCall.dll", EntryPoint = "MouseClick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MouseClick(byte AKey);
        [DllImport("KeyCall.dll", EntryPoint = "MouseDbClick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MouseDbClick(byte AKey);
        [DllImport("KeyCall.dll", EntryPoint = "KeyDown", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyDown(byte AKey, string AData);
        [DllImport("KeyCall.dll", EntryPoint = "KeyDownEx", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MKeyDownEx(string AData);
        [DllImport("KeyCall.dll", EntryPoint = "KeyUp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyUp();
        [DllImport("KeyCall.dll", EntryPoint = "KeyDownUp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyDownUp(byte AKey, string AData);
        [DllImport("KeyCall.dll", EntryPoint = "KeyDownUpEx", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeyDownUpEx(string AData);

        [DllImport("KeyCall.dll", EntryPoint = "SetWaitTick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWaitTick(int AWaitTick, int AMoveValue, int AClickTick, int AInputTick);

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out Point lpPoint);


        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        public static int MMouseDown(byte AKey)
        {
            int a = MouseDown(AKey);
            Thread.Sleep(80);
            return a;
        }


        /// <summary>
        /// 不在使用原来的move了，使用moveTo实现move
        /// </summary>
        /// <param name="AKey"></param>
        /// <param name="x">右移</param>
        /// <param name="y">【上】移y个px</param>
        /// <returns></returns>
        public static Point MMouseMove(byte AKey, int x, int y)
        {
            int a = 0;
            Point po = new Point();

            Point originPo = new Point();
            GetCursorPos(out originPo);
            Random random = new Random();
            while (true)
            {
                a = MouseMoveTo(AKey, originPo.X + x, originPo.Y - y);
                Thread.Sleep(random.Next(40, 150));
                //获取坐标

                GetCursorPos(out po);
                if (po.X != originPo.X + x || po.Y != originPo.Y - y)
                {
                    continue;
                }
                else
                { break; }
            }
            return po;
        }

        public static int MMouseMoveTo(byte AKey, int x, int y)
        {
            int a = 0;
            while (true)
            {
                Random random = new Random();
                a = MouseMoveTo(AKey, x, y);
                Thread.Sleep(random.Next(40, 150));
                //获取坐标
                Point po = new Point();
                GetCursorPos(out po);
                if (po.X != x || po.Y != y)
                {
                    continue;
                }
                else
                { break; }
            }
            return a;
        }

        public static int MMouseClick(byte AKey)
        {
            Random random = new Random();
            int a = MouseClick(AKey);
            Thread.Sleep(random.Next(40, 150));
            return a;
        }
        public static int MMouseDbClick(byte AKey)
        {
            Random random = new Random();
            int a = MouseDbClick(AKey);
            Thread.Sleep(random.Next(40, 150));
            return a;
        }

        public static int MKeyDown(byte AKey, string AData)
        {
            Random random = new Random();
            int a = KeyDown(AKey, AData);
            Thread.Sleep(random.Next(40, 150));
            return a;
        }

        public static void MZuHeKeyDownUp(byte k1, string AData)
        {
            MKeyDown(k1, AData);//该键值是采用设备键值，键值请对照“设备键值列表.txt”
            Thread.Sleep(55);
            MKeyDown(0, ""); //注:与MKeyUp()等效
            Thread.Sleep(35);
        }


        public static int MKeyUp()
        {
            Random random = new Random();
            int a = KeyUp();
            Thread.Sleep(random.Next(40, 150));
            return a;
        }

        public static int MKeyDownUp(byte AKey, string AData)
        {
            Random random = new Random();
            int a = KeyDownUp(AKey, AData);
            Thread.Sleep(random.Next(40, 150));
            return a;
        }

    }
}
