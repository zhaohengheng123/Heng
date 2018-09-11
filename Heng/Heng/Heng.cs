using Heng.Bizlogic;
using Heng.Bizlogic.entity;
using Heng.Bizlogic.Operate;
using Heng.Bizlogic.Utils;
using Newtonsoft.Json.Linq;
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
    public partial class Heng : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger("InfoLog");
        private Form1 frm1 = new Form1(1); // 全局变量
        private Form1 frm2 = new Form1(2); // 全局变量
        private Form1 frm3 = new Form1(3); // 全局变量
        private Form1 frm4 = new Form1(4); // 全局变量
        private Form1 frm5 = new Form1(5); // 全局变量
        public Heng()
        {
            InitializeComponent();
        }

        private void Heng_Load(object sender, EventArgs e)
        {
            #region 显示标签页
            frm1.FormBorderStyle = FormBorderStyle.None; // 无边框
            frm1.TopLevel = false; // 不是最顶层窗体
            frm1.setTitleHandler = setTitle;
            tabPage1.Controls.Add(frm1);  // 添加到 Panel中
            frm1.Show();     // 显示
            frm2.FormBorderStyle = FormBorderStyle.None; // 无边框
            frm2.TopLevel = false; // 不是最顶层窗体
            frm2.setTitleHandler = setTitle;
            tabPage2.Controls.Add(frm2);  // 添加到 Panel中
            frm2.Show();     // 显示
            frm3.FormBorderStyle = FormBorderStyle.None; // 无边框
            frm3.TopLevel = false; // 不是最顶层窗体
            frm3.setTitleHandler = setTitle;
            tabPage3.Controls.Add(frm3);  // 添加到 Panel中
            frm3.Show();     // 显示
            frm4.FormBorderStyle = FormBorderStyle.None; // 无边框
            frm4.TopLevel = false; // 不是最顶层窗体
            frm4.setTitleHandler = setTitle;
            tabPage4.Controls.Add(frm4);  // 添加到 Panel中
            frm4.Show();     // 显示
            frm5.FormBorderStyle = FormBorderStyle.None; // 无边框
            frm5.TopLevel = false; // 不是最顶层窗体
            frm5.setTitleHandler = setTitle;
            tabPage5.Controls.Add(frm5);  // 添加到 Panel中
            frm5.Show();     // 显示 

            #endregion
            InitTabControl();
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);

        }

        public void InitTabControl()
        {
            tabPage1.Text = Singleton.GetInstance().dicWindows[1].WindowName;
            tabPage2.Text = Singleton.GetInstance().dicWindows[2].WindowName;
            tabPage3.Text = Singleton.GetInstance().dicWindows[3].WindowName;
            tabPage4.Text = Singleton.GetInstance().dicWindows[4].WindowName;
            tabPage5.Text = Singleton.GetInstance().dicWindows[5].WindowName;
        }

        public void setTitle()
        {
            this.tabPage1.Text = StringUtil.GetShortWindowName(Singleton.GetInstance().dicWindows[1].WindowName);
            this.tabPage2.Text = StringUtil.GetShortWindowName(Singleton.GetInstance().dicWindows[2].WindowName);
            this.tabPage3.Text = StringUtil.GetShortWindowName(Singleton.GetInstance().dicWindows[3].WindowName);
            this.tabPage4.Text = StringUtil.GetShortWindowName(Singleton.GetInstance().dicWindows[4].WindowName);
            this.tabPage5.Text = StringUtil.GetShortWindowName(Singleton.GetInstance().dicWindows[5].WindowName);
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            if (Singleton.GetInstance().dicWindows.ContainsKey(e.Index + 1) && Singleton.GetInstance().dicWindows[e.Index + 1].IsActive)
            {
                e.Graphics.FillRectangle(Brushes.Green, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.Red, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }
            e.Graphics.DrawString(((TabControl)sender).TabPages[e.Index].Text,
            System.Windows.Forms.SystemInformation.MenuFont, new SolidBrush(Color.Black), e.Bounds, sf);
        }


        private void button1_Click_1(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowAPI.SetWaitTick(10, 20, 20, 30);
        }


        /// <summary>
        /// 地图放鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            MoveBiz biz = new MoveBiz(1);
            Console.WriteLine("开始时间：" + DateTime.Now.ToString());
            for (int i = 0; i < 3; i++)
            {
                DateTime dt = DateTime.Now;
                biz.MPutToMapCoor(new GameCoordinate(1, 1), true);
                Console.WriteLine(i + "次完成，用时" + (DateTime.Now - dt));
            }
            Console.WriteLine("结束时间：" + DateTime.Now.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //终极目的
            MoveBiz biz = new MoveBiz(1);
            //biz.PointPutToGameCoor(new GameCoordinate(98, 75));

            biz.GetWalkSeconds("");
        }
    }
}
