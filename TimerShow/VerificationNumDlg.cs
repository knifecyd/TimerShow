using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TimerShow
{
    public partial class VerificationNumDlg : Form
    {
        public VerificationNumDlg()
        {
            InitializeComponent();
        }

        private Point getWinPoints()
        {
            MessageBox.Show( ""  +  this.Left +  " " +  this.Right ); 
            return new Point();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            int x1, x2, y1, y2, x3,y3,x4,y4;
           
            x1 = Convert.ToInt32(TimerShow.Properties.Settings.Default.x1);
            y1 = Convert.ToInt32(TimerShow.Properties.Settings.Default.y1);

            x2 = Convert.ToInt32(TimerShow.Properties.Settings.Default.x2);
            y2 = Convert.ToInt32(TimerShow.Properties.Settings.Default.y2);

            x3 = Convert.ToInt32(TimerShow.Properties.Settings.Default.x3);
            y3 = Convert.ToInt32(TimerShow.Properties.Settings.Default.y3);

            x4 = Convert.ToInt32(TimerShow.Properties.Settings.Default.x4);
            y4 = Convert.ToInt32(TimerShow.Properties.Settings.Default.y4);
             




            Bitmap bit = new Bitmap(x1 - x2 , y1  - y2);
            Graphics g = Graphics.FromImage(bit);

            g.CopyFromScreen (new Point(x2, y2), new Point(0, 0), bit.Size);
            Bitmap newBit = this.GetSmall(bit, 2);

           

            Bitmap bit2 = new Bitmap(x3 - x4, y3 - y4);
            Graphics g2 = Graphics.FromImage(bit2);

            g2.CopyFromScreen(new Point(x4, y4), new Point(0, 0), bit2.Size);
            Bitmap newBit2 = bit2;

            this.pictureBox1.Image = newBit;
            this.pictureBox1.Show();

            this.pictureBox2.Image = newBit2;
            this.pictureBox2.Show();



        }
        /// <summary>
        /// 获取缩小后的图片
        /// </summary>
        /// <param name="bm">要缩小的图片</param>
        /// <param name="times">要缩小的倍数</param>
        /// <returns></returns>
        private Bitmap GetSmall(Bitmap bm, double times)
        {
            int nowWidth = (int)(bm.Width * times);
            int nowHeight = (int)(bm.Height * times);
            Bitmap newbm = new Bitmap(nowWidth, nowHeight);//新建一个放大后大小的图片

            if (times >= 1 && times <= 1.1)
            {
                newbm = bm;
            }
            else
            {
                Graphics g = Graphics.FromImage(newbm);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.DrawImage(bm, new Rectangle(0, 0, nowWidth, nowHeight), new Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }
            return newbm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                     
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.getWinPoints();
        }

    }
}
