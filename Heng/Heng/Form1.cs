using Heng.Bizlogic;
using Heng.Bizlogic.entity;
using Heng.Bizlogic.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heng
{
    public partial class Form1 : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
        public Form1(int windowNum)
        {
            this.WindowNum = windowNum;
            InitializeComponent();
        }

        public int WindowNum { get; set; }

        public delegate void setTitleDelegate();

        public setTitleDelegate setTitleHandler;//委托对象


        private void Form1_Load(object sender, EventArgs e)
        {
            #region dll初始化
            BindDDL();
            refreshBtn();
            #endregion

        }
        public void refreshBtn()
        {
            if (Singleton.GetInstance().dicWindows[WindowNum].IsActive)
                btnStart.Text = "停止";
            else
                btnStart.Text = "启动";

        }


        #region 加载页面ddl
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

        //结构体布局 本机位置
        [StructLayout(LayoutKind.Sequential)]
        struct NativeRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        [DllImport("user32.dll")]
        static extern bool GetWindowRect(HandleRef hwnd, out NativeRECT rect);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string strClass, string strWindow);

        //该函数获取一个窗口句柄,该窗口雷鸣和窗口名与给定字符串匹配 hwnParent=Null从桌面窗口查找
        [DllImport("user32.dll")]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter,
            string strClass, string strWindow);

        /// <summary>
        /// 获取窗口位置
        /// </summary>
        /// <param name="windowName"></param>
        /// <returns></returns>
        public Point GetWindowPosition(string windowName)
        {
            Point endPosition = new Point(0, 0);
            NativeRECT rect;
            //获取主窗体句柄
            IntPtr ptrTaskbar = FindWindow("MHXYMainFrame", windowName);
            if (ptrTaskbar == IntPtr.Zero)
            {
                MessageBox.Show("No windows found");
                return endPosition;
            }
            //获取窗体中"button1"按钮
            IntPtr ptrStartBtn = FindWindowEx(ptrTaskbar, IntPtr.Zero, "WSGAME", null);
            if (ptrStartBtn == IntPtr.Zero)
            {
                MessageBox.Show("No windows found");
                return endPosition;
            }
            //获取窗体大小
            GetWindowRect(new HandleRef(this, ptrStartBtn), out rect);
            endPosition.X = rect.left;
            endPosition.Y = rect.bottom;

            return endPosition;
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
        #endregion

        private void refreshddl_Click(object sender, EventArgs e)
        {
            BindDDL();
        }

        public void BindDDL()
        {
            #region dll初始化
            comboBox1.Items.Clear();
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
            #endregion
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "请选择..")
            {
                return;
            }
            for (int i = 0; i < Singleton.GetInstance().dicWindows.Count; i++)
            {
                if (i + 1 == WindowNum)
                {
                    continue;
                }
                else if (Singleton.GetInstance().dicWindows[i + 1].WindowName == comboBox1.Text)
                {
                    MessageBox.Show("该窗口已经被监控，请勿重复监控");
                    return;
                }
            }
            Point point= GetWindowPosition(comboBox1.Text);

            SingletonHandler.AddDicWindows(WindowNum, new Window() { WindowName = comboBox1.Text, IsActive = false,Point=point });
            setTitleHandler();

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "请选择..")
            {
                MessageBox.Show("还没有监控窗口！");
                return;
            }
            if (comboBox1.Text.Contains("梦幻西游"))
            {
                MessageBox.Show("先进游戏再监控窗口吧！");
                return;
            }
            //设置启动
            SingletonHandler.EditWindowActive(WindowNum);
            refreshBtn();
            setTitleHandler();
        }
    }
}
