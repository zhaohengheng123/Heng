namespace KeyDemo
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtEdit1 = new System.Windows.Forms.TextBox();
            this.btnGetTemp1 = new System.Windows.Forms.Button();
            this.btnTempC = new System.Windows.Forms.Button();
            this.btnGetTempN = new System.Windows.Forms.Button();
            this.btnGetTemp2 = new System.Windows.Forms.Button();
            this.richTxtBoxTemp = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnGetHumidity2 = new System.Windows.Forms.Button();
            this.btnGetHumidity1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timerClick = new System.Windows.Forms.Timer(this.components);
            this.timerDbClick = new System.Windows.Forms.Timer(this.components);
            this.timerDownMove = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtEdit1);
            this.groupBox1.Controls.Add(this.btnGetTemp1);
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // txtEdit1
            // 
            this.txtEdit1.Location = new System.Drawing.Point(120, 20);
            this.txtEdit1.Name = "txtEdit1";
            this.txtEdit1.Size = new System.Drawing.Size(243, 21);
            this.txtEdit1.TabIndex = 6;
            this.txtEdit1.Text = "ABCDEFG";
            // 
            // btnGetTemp1
            // 
            this.btnGetTemp1.Location = new System.Drawing.Point(15, 14);
            this.btnGetTemp1.Name = "btnGetTemp1";
            this.btnGetTemp1.Size = new System.Drawing.Size(86, 30);
            this.btnGetTemp1.TabIndex = 3;
            this.btnGetTemp1.Text = "输入字符串";
            this.btnGetTemp1.UseVisualStyleBackColor = true;
            this.btnGetTemp1.Click += new System.EventHandler(this.btnGetTemp1_Click);
            // 
            // btnTempC
            // 
            this.btnTempC.Location = new System.Drawing.Point(512, 149);
            this.btnTempC.Name = "btnTempC";
            this.btnTempC.Size = new System.Drawing.Size(75, 23);
            this.btnTempC.TabIndex = 7;
            this.btnTempC.Text = "清空日志数据";
            this.btnTempC.UseVisualStyleBackColor = true;
            this.btnTempC.Click += new System.EventHandler(this.btnTempC_Click);
            // 
            // btnGetTempN
            // 
            this.btnGetTempN.ForeColor = System.Drawing.Color.Black;
            this.btnGetTempN.Location = new System.Drawing.Point(19, 53);
            this.btnGetTempN.Name = "btnGetTempN";
            this.btnGetTempN.Size = new System.Drawing.Size(87, 30);
            this.btnGetTempN.TabIndex = 5;
            this.btnGetTempN.Text = "鼠标双击";
            this.btnGetTempN.UseVisualStyleBackColor = true;
            this.btnGetTempN.Click += new System.EventHandler(this.btnGetTempN_Click);
            // 
            // btnGetTemp2
            // 
            this.btnGetTemp2.ForeColor = System.Drawing.Color.Black;
            this.btnGetTemp2.Location = new System.Drawing.Point(18, 17);
            this.btnGetTemp2.Name = "btnGetTemp2";
            this.btnGetTemp2.Size = new System.Drawing.Size(87, 30);
            this.btnGetTemp2.TabIndex = 4;
            this.btnGetTemp2.Text = "鼠标单击";
            this.btnGetTemp2.UseVisualStyleBackColor = true;
            this.btnGetTemp2.Click += new System.EventHandler(this.btnGetTemp2_Click);
            // 
            // richTxtBoxTemp
            // 
            this.richTxtBoxTemp.Location = new System.Drawing.Point(14, 149);
            this.richTxtBoxTemp.Name = "richTxtBoxTemp";
            this.richTxtBoxTemp.Size = new System.Drawing.Size(492, 133);
            this.richTxtBoxTemp.TabIndex = 1;
            this.richTxtBoxTemp.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnGetHumidity2);
            this.groupBox2.Controls.Add(this.btnGetHumidity1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(8, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 109);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(324, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 35);
            this.button2.TabIndex = 12;
            this.button2.Text = "鼠标定位";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(163, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "拖动测试有延时2秒";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "X";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(43, 21);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "30";
            // 
            // btnGetHumidity2
            // 
            this.btnGetHumidity2.Location = new System.Drawing.Point(14, 61);
            this.btnGetHumidity2.Name = "btnGetHumidity2";
            this.btnGetHumidity2.Size = new System.Drawing.Size(87, 35);
            this.btnGetHumidity2.TabIndex = 3;
            this.btnGetHumidity2.Text = "鼠标拖动";
            this.btnGetHumidity2.UseVisualStyleBackColor = true;
            this.btnGetHumidity2.Click += new System.EventHandler(this.btnGetHumidity2_Click);
            // 
            // btnGetHumidity1
            // 
            this.btnGetHumidity1.Location = new System.Drawing.Point(15, 20);
            this.btnGetHumidity1.Name = "btnGetHumidity1";
            this.btnGetHumidity1.Size = new System.Drawing.Size(87, 35);
            this.btnGetHumidity1.TabIndex = 0;
            this.btnGetHumidity1.Text = "鼠标移动";
            this.btnGetHumidity1.UseVisualStyleBackColor = true;
            this.btnGetHumidity1.Click += new System.EventHandler(this.btnGetHumidity1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(248, 51);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(43, 21);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "30";
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(14, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "按键、放开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.checkBox11);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.checkBox10);
            this.groupBox3.Controls.Add(this.btnTempC);
            this.groupBox3.Controls.Add(this.checkBox9);
            this.groupBox3.Controls.Add(this.checkBox8);
            this.groupBox3.Controls.Add(this.richTxtBoxTemp);
            this.groupBox3.Controls.Add(this.checkBox7);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.checkBox4);
            this.groupBox3.Controls.Add(this.checkBox5);
            this.groupBox3.Location = new System.Drawing.Point(8, 266);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(608, 275);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(474, 72);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(87, 30);
            this.button7.TabIndex = 20;
            this.button7.Text = "按键、放开";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(165, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(126, 30);
            this.button5.TabIndex = 19;
            this.button5.Text = "按键输入(系统)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(15, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(124, 30);
            this.button4.TabIndex = 18;
            this.button4.Text = "按键、放开(系统)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(122, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "左：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "右：";
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(403, 108);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(42, 16);
            this.checkBox11.TabIndex = 15;
            this.checkBox11.Text = "WIN";
            this.checkBox11.UseVisualStyleBackColor = true;
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(319, 108);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(54, 16);
            this.checkBox10.TabIndex = 14;
            this.checkBox10.Text = "Shift";
            this.checkBox10.UseVisualStyleBackColor = true;
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(235, 109);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(42, 16);
            this.checkBox9.TabIndex = 13;
            this.checkBox9.Text = "Alt";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(150, 109);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(48, 16);
            this.checkBox8.TabIndex = 12;
            this.checkBox8.Text = "Ctrl";
            this.checkBox8.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(403, 86);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(42, 16);
            this.checkBox7.TabIndex = 11;
            this.checkBox7.Text = "WIN";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 108);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "按键输入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(319, 86);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(54, 16);
            this.checkBox6.TabIndex = 10;
            this.checkBox6.Text = "Shift";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(150, 86);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(48, 16);
            this.checkBox4.TabIndex = 8;
            this.checkBox4.Text = "Ctrl";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(235, 86);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(42, 16);
            this.checkBox5.TabIndex = 9;
            this.checkBox5.Text = "Alt";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Controls.Add(this.checkBox2);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.btnGetTemp2);
            this.groupBox4.Controls.Add(this.btnGetTempN);
            this.groupBox4.Location = new System.Drawing.Point(8, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(608, 90);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(431, 17);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 30);
            this.button6.TabIndex = 11;
            this.button6.Text = "延时参数";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(167, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "单、双击测试有延时2秒";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(361, 41);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(54, 16);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "右键 ";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(252, 41);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 8;
            this.checkBox2.Text = "中键";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(124, 41);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 16);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "左键 ";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // timerClick
            // 
            this.timerClick.Interval = 2000;
            this.timerClick.Tick += new System.EventHandler(this.timerClick_Tick);
            // 
            // timerDbClick
            // 
            this.timerDbClick.Interval = 2000;
            this.timerDbClick.Tick += new System.EventHandler(this.timerDbClick_Tick);
            // 
            // timerDownMove
            // 
            this.timerDownMove.Interval = 2000;
            this.timerDownMove.Tick += new System.EventHandler(this.timerDownMove_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 580);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "按键调用示例";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTxtBoxTemp;
        private System.Windows.Forms.Button btnGetTemp2;
        private System.Windows.Forms.Button btnGetTemp1;
        private System.Windows.Forms.Button btnGetTempN;
        private System.Windows.Forms.TextBox txtEdit1;
        private System.Windows.Forms.Button btnTempC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGetHumidity1;
        private System.Windows.Forms.Button btnGetHumidity2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerClick;
        private System.Windows.Forms.Timer timerDbClick;
        private System.Windows.Forms.Timer timerDownMove;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
    }
}

