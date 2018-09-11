using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heng
{
    public partial class BasicActionTest : Form
    {

        private Form2 frmEmbed = new Form2(); // 全局变量

        private Form3 frmEmbed2 = new Form3(); // 全局变量
        public BasicActionTest()
        {
            InitializeComponent();
        }

        //结构体布局 本机位置
        [StructLayout(LayoutKind.Sequential)]
        struct NativeRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        //将枚举作为位域处理
        [Flags]
        enum MouseEventFlag : uint //设置鼠标动作的键值
        {
            Move = 0x0001,               //发生移动
            LeftDown = 0x0002,           //鼠标按下左键
            LeftUp = 0x0004,             //鼠标松开左键
            RightDown = 0x0008,          //鼠标按下右键
            RightUp = 0x0010,            //鼠标松开右键
            MiddleDown = 0x0020,         //鼠标按下中键
            MiddleUp = 0x0040,           //鼠标松开中键
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,              //鼠标轮被移动
            VirtualDesk = 0x4000,        //虚拟桌面
            Absolute = 0x8000
        }

        //设置鼠标位置
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        //设置鼠标按键和动作
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy,
            uint data, UIntPtr extraInfo); //UIntPtr指针多句柄类型

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string strClass, string strWindow);

        //该函数获取一个窗口句柄,该窗口雷鸣和窗口名与给定字符串匹配 hwnParent=Null从桌面窗口查找
        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
            string strClass, string strWindow);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(HandleRef hwnd, out NativeRECT rect);

        [DllImport("user32.DLL")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);  //导入模拟键盘的方法

        //定义变量
        const int AnimationCount = 80;
        private Point endPosition;



        private delegate bool WNDENUMPROC(IntPtr hWnd, int lParam);

        //用来遍历所有窗口 
        [DllImport("user32.dll")]
        private static extern bool EnumWindows(WNDENUMPROC lpEnumFunc, int lParam);

        //获取窗口Text 
        [DllImport("user32.dll")]
        private static extern int GetWindowTextW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        //获取窗口类名 
        [DllImport("user32.dll")]
        private static extern int GetClassNameW(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]StringBuilder lpString, int nMaxCount);

        //自定义一个类，用来保存句柄信息，在遍历的时候，随便也用空上句柄来获取些信息，呵呵 
        public struct WindowInfo
        {
            public IntPtr hWnd;
            public string szWindowName;
            public string szClassName;
        }

        public List<WindowInfo> GetAllDesktopWindows()
        {
            //用来保存窗口对象 列表
            List<WindowInfo> wndList = new List<WindowInfo>();

            //enum all desktop windows 
            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                WindowInfo wnd = new WindowInfo();

                StringBuilder sb = new StringBuilder(256);
                //get hwnd 
                wnd.hWnd = hWnd;
                //get window name  
                GetWindowTextW(hWnd, sb, sb.Capacity);
                wnd.szWindowName = sb.ToString();
                //get window class 
                GetClassNameW(hWnd, sb, sb.Capacity);
                wnd.szClassName = sb.ToString();
                //add it into list 
                wndList.Add(wnd);
                return true;
            }, 0);


            return wndList;
        }



        private void test()
        {
            NativeRECT rect;
            //获取主窗体句柄
            //获取主窗体句柄
            IntPtr ptrTaskbar = FindWindow("MHXYMainFrame", "梦幻西游 ONLINE - (上海2区[东方明珠] - 吐吐吐丶泡泡[17570284])");
            if (ptrTaskbar == IntPtr.Zero)
            {
                MessageBox.Show("No windows found!");
                return;
            }
            //获取窗体中"WSGAME"按钮
            IntPtr ptrStartBtn = FindWindowEx(ptrTaskbar, IntPtr.Zero, "WSGAME", null);
            if (ptrStartBtn == IntPtr.Zero)
            {
                MessageBox.Show("No windows found!");
                return;
            }
            //获取窗体大小
            GetWindowRect(new HandleRef(this, ptrStartBtn), out rect);
            endPosition.X = (rect.left + rect.right) / 2;
            endPosition.Y = (rect.top + rect.bottom) / 2;

            ////窗体大小为640*480
            ////判断点击按钮
            SetCursorPos(endPosition.X, endPosition.Y);

            Thread.Sleep(3000);

            IntPtr ptrTaskbar1 = FindWindow("MHXYMainFrame", "梦幻西游 ONLINE");
            if (ptrTaskbar1 == IntPtr.Zero)
            {
                MessageBox.Show("No windows found!");
                return;
            }
            //获取窗体中"WSGAME"按钮
            IntPtr ptrStartBtn1 = FindWindowEx(ptrTaskbar1, IntPtr.Zero, "WSGAME", null);
            if (ptrStartBtn1 == IntPtr.Zero)
            {
                MessageBox.Show("No windows found!");
                return;
            }
            //获取窗体大小
            GetWindowRect(new HandleRef(this, ptrStartBtn1), out rect);
            endPosition.X = (rect.left + rect.right) / 2;
            endPosition.Y = (rect.top + rect.bottom) / 2;

            ////窗体大小为640*480
            ////判断点击按钮
            SetCursorPos(endPosition.X, endPosition.Y);

            Thread.Sleep(3000);

            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            keybd_event(0x70, 0, 0, 0);
            keybd_event(0x70, 0, 2, 0);




            //string point = String.Format("{0},{1}", MousePosition.X, MousePosition.Y);

        }

        private void a1_Click(object sender, EventArgs e)
        {
            test();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载ddl GetAllDesktopWindows()
            //将数组项一一添加到checkedListBox上
            comboBox1.Items.Add("请选择..");
            List<WindowInfo> listWindows = GetAllDesktopWindows();

            foreach (WindowInfo item in listWindows)
            {
                //梦幻
                if (item.szWindowName.Contains("梦幻西游 ONLINE"))
                {
                    comboBox1.Items.Add(item.szWindowName);
                }
            }
            comboBox1.SelectedItem = "请选择..";//初始化为请选择


            frmEmbed.FormBorderStyle = FormBorderStyle.None; // 无边框
            frmEmbed.TopLevel = false; // 不是最顶层窗体
            panel1.Controls.Add(frmEmbed);  // 添加到 Panel中
            frmEmbed.Show();     // 显示

            frmEmbed2.FormBorderStyle = FormBorderStyle.None; // 无边框
            frmEmbed2.TopLevel = false; // 不是最顶层窗体
            panel2.Controls.Add(frmEmbed2);  // 添加到 Panel中
            frmEmbed2.Show();     // 显示

        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            //刷新缓存等操作

        }
    }
}
