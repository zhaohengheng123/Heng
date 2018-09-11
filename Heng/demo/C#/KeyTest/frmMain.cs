using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace KeyDemo
{
    public partial class frmMain : Form
    {
        [DllImport("KeyCall.dll", EntryPoint = "GetKeyDev", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MGetKeyDev();
        [DllImport("KeyCall.dll", EntryPoint = "KeySendChar", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int KeySendChar(string AData);
        [DllImport("KeyCall.dll", EntryPoint = "MouseDown", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MMouseDown(byte AKey);
        [DllImport("KeyCall.dll", EntryPoint = "MouseMove", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MMouseMove(byte AKey, int x, int y);

        [DllImport("KeyCall.dll", EntryPoint = "MouseMoveToEx", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MMouseMoveToEx(byte AKey, int x, int y);
        [DllImport("KeyCall.dll", EntryPoint = "MouseMoveTo", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MMouseMoveTo(byte AKey, int x, int y);
        [DllImport("KeyCall.dll", EntryPoint = "MouseClick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MMouseClick(byte AKey);
        [DllImport("KeyCall.dll", EntryPoint = "MouseDbClick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MMouseDbClick(byte AKey);
        [DllImport("KeyCall.dll", EntryPoint = "KeyDown", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MKeyDown(byte AKey, string AData);
        [DllImport("KeyCall.dll", EntryPoint = "KeyDownEx", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MKeyDownEx(string AData);
        [DllImport("KeyCall.dll", EntryPoint = "KeyUp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MKeyUp();
        [DllImport("KeyCall.dll", EntryPoint = "KeyDownUp", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MKeyDownUp(byte AKey, string AData);
        [DllImport("KeyCall.dll", EntryPoint = "KeyDownUpEx", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int MKeyDownUpEx(string AData);

        [DllImport("KeyCall.dll", EntryPoint = "SetWaitTick", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWaitTick(int AWaitTick, int AMoveValue, int AClickTick, int AInputTick);


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

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGetTemp1_Click(object sender, EventArgs e)
        {
            string a = "";
            a = txtEdit1.Text;
            richTxtBoxTemp.Focus();
            KeySendChar(a);
        }

        private void btnGetTemp2_Click(object sender, EventArgs e)
        {
            timerClick.Enabled = true;
        }

        private void btnGetTempN_Click(object sender, EventArgs e)
        {
            timerDbClick.Enabled = true;
        }

        private void btnTempC_Click(object sender, EventArgs e)
        {
            richTxtBoxTemp.Text = "";
        }

        private void btnGetHumidity1_Click(object sender, EventArgs e)
        {
            MMouseMove(0, Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text));
        }

        private void btnGetHumidity2_Click(object sender, EventArgs e)
        {
            timerDownMove.Enabled = true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Byte vKey;

            vKey = 0;
            if(checkBox4.Checked)
                vKey += 1;
            if(checkBox5.Checked)
                vKey += 4;
            if(checkBox6.Checked)
                vKey += 2;
            if(checkBox7.Checked)
                vKey += 8;
            if(checkBox8.Checked)
                vKey += 0x10;
            if(checkBox9.Checked)
                vKey += 0x40;
            if(checkBox10.Checked)
                vKey += 0x20;
            if(checkBox11.Checked)
                vKey += 0x80;
            richTxtBoxTemp.Focus();
            MKeyDown(vKey, Chr(0x1e) + Chr(0x1f));//该键值是采用设备键值，键值请对照“设备键值列表.txt”
            Thread.Sleep(15);
            MKeyUp();   //注：与MKeyDown(0, Chr(0x00))等效
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTxtBoxTemp.Focus();
            MKeyDownUp(0, Chr(0x1e));
        }

        private void timerClick_Tick(object sender, EventArgs e)
        {
            Byte vKey;
            timerClick.Enabled = false;
            vKey = 0;
            if (checkBox1.Checked)
                vKey += 1;
            if (checkBox2.Checked)
                vKey += 4;
            if (checkBox3.Checked)
                vKey += 2;
            MMouseClick(vKey);
        }

        private void timerDbClick_Tick(object sender, EventArgs e)
        {
            Byte vKey;
            timerDbClick.Enabled = false;
            vKey = 0;
            if (checkBox1.Checked)
                vKey += 1;
            if (checkBox2.Checked)
                vKey += 4;
            if (checkBox3.Checked)
                vKey += 2;
            MMouseDbClick(vKey);
        }

        private void timerDownMove_Tick(object sender, EventArgs e)
        {
            Byte vKey;
            timerDownMove.Enabled = false;
            vKey = 0;
            if (checkBox1.Checked)
                vKey += 1;
            if (checkBox2.Checked)
                vKey += 4;
            if (checkBox3.Checked)
                vKey += 2;
            MMouseDown(vKey);
            Thread.Sleep(15);
            MMouseMove(vKey, Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text));
            Thread.Sleep(15);
            MMouseDown(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MMouseMoveTo(0, Convert.ToInt16(textBox1.Text), Convert.ToInt16(textBox2.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTxtBoxTemp.Focus();
            MKeyDownEx("A1234");
            Thread.Sleep(15);
            MKeyDownEx("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTxtBoxTemp.Focus();
            MKeyDownUpEx("A123");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SetWaitTick(30, 6, 20, 30);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Byte vKey;

            vKey = 0;
            if (checkBox4.Checked)
                vKey += 1;
            if (checkBox5.Checked)
                vKey += 4;
            if (checkBox6.Checked)
                vKey += 2;
            if (checkBox7.Checked)
                vKey += 8;
            if (checkBox8.Checked)
                vKey += 0x10;
            if (checkBox9.Checked)
                vKey += 0x40;
            if (checkBox10.Checked)
                vKey += 0x20;
            if (checkBox11.Checked)
                vKey += 0x80;
            richTxtBoxTemp.Focus();
          //  MKeyDown(vKey, Chr(0x20) + Chr(0x1f) + Chr(0x1e));//该键值是采用设备键值，键值请对照“设备键值列表.txt”
            MKeyDown(vKey, Chr(0x1e));//该键值是采用设备键值，键值请对照“设备键值列表.txt”
            Thread.Sleep(15);
            MKeyDown(0, ""); //注:与MKeyUp()等效
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
