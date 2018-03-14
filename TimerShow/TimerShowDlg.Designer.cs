namespace TimerShow
{
    partial class TimerShowDlg
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
            this.SendPriceBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textSS = new System.Windows.Forms.TextBox();
            this.textMM = new System.Windows.Forms.TextBox();
            this.textFPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnAutoAdd = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.delaySeconds = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ForwordInternalPrice = new System.Windows.Forms.TextBox();
            this.SendPricetimer = new System.Windows.Forms.Timer(this.components);
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.subMitReason = new System.Windows.Forms.TextBox();
            this.lowest_pict_Box = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.time_pic_Box = new System.Windows.Forms.PictureBox();
            this.time_textBox = new System.Windows.Forms.TextBox();
            this.textHH = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Log = new System.Windows.Forms.TextBox();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.curXYLabel = new System.Windows.Forms.Label();
            this.but5 = new System.Windows.Forms.Button();
            this.label_now_time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sysTimeForceSendPricetextBox = new System.Windows.Forms.TextBox();
            this.SysTimetextBox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.HightPriceText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tAutoDetectorextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.my_price_pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowest_pict_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_pic_Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_price_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SendPriceBtn
            // 
            this.SendPriceBtn.Location = new System.Drawing.Point(432, 10);
            this.SendPriceBtn.Name = "SendPriceBtn";
            this.SendPriceBtn.Size = new System.Drawing.Size(84, 23);
            this.SendPriceBtn.TabIndex = 5;
            this.SendPriceBtn.Text = "出价";
            this.SendPriceBtn.UseVisualStyleBackColor = true;
            this.SendPriceBtn.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(351, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "快捷键";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(260, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 21);
            this.textBox2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "强制出价时间(hh:mm:ss)";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(522, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "取消强制出价";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "OCR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "最低价格";
            // 
            // textPrice
            // 
            this.textPrice.Enabled = false;
            this.textPrice.Location = new System.Drawing.Point(53, 63);
            this.textPrice.Name = "textPrice";
            this.textPrice.Size = new System.Drawing.Size(60, 21);
            this.textPrice.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = ":";
            // 
            // textSS
            // 
            this.textSS.Enabled = false;
            this.textSS.Location = new System.Drawing.Point(83, 10);
            this.textSS.Name = "textSS";
            this.textSS.Size = new System.Drawing.Size(27, 21);
            this.textSS.TabIndex = 18;
            // 
            // textMM
            // 
            this.textMM.Enabled = false;
            this.textMM.Location = new System.Drawing.Point(44, 10);
            this.textMM.Name = "textMM";
            this.textMM.Size = new System.Drawing.Size(29, 21);
            this.textMM.TabIndex = 19;
            // 
            // textFPrice
            // 
            this.textFPrice.Enabled = false;
            this.textFPrice.Location = new System.Drawing.Point(285, 63);
            this.textFPrice.Name = "textFPrice";
            this.textFPrice.Size = new System.Drawing.Size(60, 21);
            this.textFPrice.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 20;
            this.label5.Text = "提交价格";
            // 
            // BtnAutoAdd
            // 
            this.BtnAutoAdd.Location = new System.Drawing.Point(351, 36);
            this.BtnAutoAdd.Name = "BtnAutoAdd";
            this.BtnAutoAdd.Size = new System.Drawing.Size(109, 28);
            this.BtnAutoAdd.TabIndex = 24;
            this.BtnAutoAdd.Text = "出价（自动加价）";
            this.BtnAutoAdd.UseVisualStyleBackColor = true;
            this.BtnAutoAdd.Click += new System.EventHandler(this.BtnAutoAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "延迟时间";
            // 
            // delaySeconds
            // 
            this.delaySeconds.Location = new System.Drawing.Point(71, 36);
            this.delaySeconds.Name = "delaySeconds";
            this.delaySeconds.Size = new System.Drawing.Size(39, 21);
            this.delaySeconds.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "提前X百";
            // 
            // ForwordInternalPrice
            // 
            this.ForwordInternalPrice.Location = new System.Drawing.Point(169, 34);
            this.ForwordInternalPrice.Name = "ForwordInternalPrice";
            this.ForwordInternalPrice.Size = new System.Drawing.Size(60, 21);
            this.ForwordInternalPrice.TabIndex = 29;
            // 
            // SendPricetimer
            // 
            this.SendPricetimer.Enabled = true;
            this.SendPricetimer.Interval = 80;
            this.SendPricetimer.Tick += new System.EventHandler(this.SendPricetimer_Tick);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(466, 40);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(76, 21);
            this.textBox3.TabIndex = 30;
            // 
            // subMitReason
            // 
            this.subMitReason.Enabled = false;
            this.subMitReason.Location = new System.Drawing.Point(5, 118);
            this.subMitReason.Name = "subMitReason";
            this.subMitReason.ReadOnly = true;
            this.subMitReason.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.subMitReason.Size = new System.Drawing.Size(592, 21);
            this.subMitReason.TabIndex = 32;
            // 
            // lowest_pict_Box
            // 
            this.lowest_pict_Box.Location = new System.Drawing.Point(81, 90);
            this.lowest_pict_Box.Name = "lowest_pict_Box";
            this.lowest_pict_Box.Size = new System.Drawing.Size(70, 22);
            this.lowest_pict_Box.TabIndex = 34;
            this.lowest_pict_Box.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 35;
            this.label9.Text = "最低价格:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(155, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 12);
            this.label10.TabIndex = 37;
            this.label10.Text = "time(HH:MM:SS):";
            // 
            // time_pic_Box
            // 
            this.time_pic_Box.Location = new System.Drawing.Point(250, 88);
            this.time_pic_Box.Name = "time_pic_Box";
            this.time_pic_Box.Size = new System.Drawing.Size(70, 22);
            this.time_pic_Box.TabIndex = 36;
            this.time_pic_Box.TabStop = false;
            // 
            // time_textBox
            // 
            this.time_textBox.Location = new System.Drawing.Point(326, 91);
            this.time_textBox.Name = "time_textBox";
            this.time_textBox.Size = new System.Drawing.Size(100, 21);
            this.time_textBox.TabIndex = 38;
            // 
            // textHH
            // 
            this.textHH.Enabled = false;
            this.textHH.Location = new System.Drawing.Point(5, 10);
            this.textHH.Name = "textHH";
            this.textHH.Size = new System.Drawing.Size(29, 21);
            this.textHH.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = ":";
            // 
            // Log
            // 
            this.Log.Enabled = false;
            this.Log.Location = new System.Drawing.Point(7, 142);
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Log.Size = new System.Drawing.Size(592, 21);
            this.Log.TabIndex = 42;
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // curXYLabel
            // 
            this.curXYLabel.AutoSize = true;
            this.curXYLabel.Location = new System.Drawing.Point(10, 169);
            this.curXYLabel.Name = "curXYLabel";
            this.curXYLabel.Size = new System.Drawing.Size(65, 12);
            this.curXYLabel.TabIndex = 43;
            this.curXYLabel.Text = "curXYLabel";
            // 
            // but5
            // 
            this.but5.Location = new System.Drawing.Point(406, 68);
            this.but5.Name = "but5";
            this.but5.Size = new System.Drawing.Size(75, 23);
            this.but5.TabIndex = 44;
            this.but5.Text = "取消快捷键";
            this.but5.UseVisualStyleBackColor = true;
            this.but5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label_now_time
            // 
            this.label_now_time.AutoSize = true;
            this.label_now_time.Location = new System.Drawing.Point(321, 169);
            this.label_now_time.Name = "label_now_time";
            this.label_now_time.Size = new System.Drawing.Size(59, 12);
            this.label_now_time.TabIndex = 45;
            this.label_now_time.Text = "当前时间:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 47;
            this.label3.Text = "系统时间强出(hh:mm:ss)";
            // 
            // sysTimeForceSendPricetextBox
            // 
            this.sysTimeForceSendPricetextBox.Location = new System.Drawing.Point(253, 163);
            this.sysTimeForceSendPricetextBox.Name = "sysTimeForceSendPricetextBox";
            this.sysTimeForceSendPricetextBox.Size = new System.Drawing.Size(60, 21);
            this.sysTimeForceSendPricetextBox.TabIndex = 46;
            this.sysTimeForceSendPricetextBox.Text = "11:29:55";
            // 
            // SysTimetextBox
            // 
            this.SysTimetextBox.Enabled = false;
            this.SysTimetextBox.Location = new System.Drawing.Point(385, 163);
            this.SysTimetextBox.Name = "SysTimetextBox";
            this.SysTimetextBox.ReadOnly = true;
            this.SysTimetextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SysTimetextBox.Size = new System.Drawing.Size(75, 21);
            this.SysTimetextBox.TabIndex = 49;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(475, 166);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox4.Size = new System.Drawing.Size(92, 21);
            this.textBox4.TabIndex = 50;
            // 
            // HightPriceText
            // 
            this.HightPriceText.Enabled = false;
            this.HightPriceText.Location = new System.Drawing.Point(160, 65);
            this.HightPriceText.Name = "HightPriceText";
            this.HightPriceText.Size = new System.Drawing.Size(60, 21);
            this.HightPriceText.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(128, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "最高";
            // 
            // tAutoDetectorextBox
            // 
            this.tAutoDetectorextBox.Location = new System.Drawing.Point(410, 191);
            this.tAutoDetectorextBox.Name = "tAutoDetectorextBox";
            this.tAutoDetectorextBox.Size = new System.Drawing.Size(157, 21);
            this.tAutoDetectorextBox.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(324, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 54;
            this.label12.Text = "自动检测提示：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(492, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 55;
            this.button4.Text = "test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_2);
            // 
            // my_price_pictureBox
            // 
            this.my_price_pictureBox.Location = new System.Drawing.Point(275, 36);
            this.my_price_pictureBox.Name = "my_price_pictureBox";
            this.my_price_pictureBox.Size = new System.Drawing.Size(70, 22);
            this.my_price_pictureBox.TabIndex = 56;
            this.my_price_pictureBox.TabStop = false;
            // 
            // TimerShowDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 224);
            this.Controls.Add(this.my_price_pictureBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tAutoDetectorextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.HightPriceText);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.SysTimetextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sysTimeForceSendPricetextBox);
            this.Controls.Add(this.label_now_time);
            this.Controls.Add(this.but5);
            this.Controls.Add(this.curXYLabel);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textHH);
            this.Controls.Add(this.time_textBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.time_pic_Box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lowest_pict_Box);
            this.Controls.Add(this.subMitReason);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.ForwordInternalPrice);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.delaySeconds);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnAutoAdd);
            this.Controls.Add(this.textFPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textMM);
            this.Controls.Add(this.textSS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SendPriceBtn);
            this.KeyPreview = true;
            this.Name = "TimerShowDlg";
            this.Text = "TimerShow";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowest_pict_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time_pic_Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.my_price_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendPriceBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textSS;
        private System.Windows.Forms.TextBox textMM;
        private System.Windows.Forms.TextBox textFPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnAutoAdd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox delaySeconds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ForwordInternalPrice;
        private System.Windows.Forms.Timer SendPricetimer;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TextBox subMitReason;
        private System.Windows.Forms.PictureBox lowest_pict_Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox time_pic_Box;
        private System.Windows.Forms.TextBox time_textBox;
        private System.Windows.Forms.TextBox textHH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Log;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Label curXYLabel;
        private System.Windows.Forms.Button but5;
        private System.Windows.Forms.Label label_now_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox sysTimeForceSendPricetextBox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox SysTimetextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HightPriceText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tAutoDetectorextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox my_price_pictureBox;
    }
}

