using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using MouseKeyboardLibrary;
using System.Diagnostics.Tracing;



namespace TimerShow
{
    public partial class TimerShowDlg : Form
    {


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
        static extern void mouse_event(MouseEventFlag flags,
            int dx, int dy,
            uint data,
            UIntPtr extraInfo); //UIntPtr指针多句柄类型


        /*设置强制出价标志，只强制出价一次*/
        static Boolean b_force_send_price = false;
        OcrUtil ocrUtil = null;
        // Tracing tc = null;

        /*  -----    */

        public TimerShowDlg()
        {
            InitializeComponent();
            b_force_send_price = false;
            ocrUtil = new OcrUtil();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // addPrice.Text = "600";
            textBox2.Text = "11:29:56";
            delaySeconds.Text = "0";
            ForwordInternalPrice.Text = "100";
            subMitReason.Text = "";

            HookTestWinForm_Load(sender, e);

        }

        /* 定时器，暂时取消，读取的是系统的时间
          private void timer1_Tick(object sender, EventArgs e)
         {
             this.Time_Text.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss fff");
             this.textBox1.Text = Control.MousePosition.X.ToString() + " | " +
             Control.MousePosition.Y.ToString();

             //加入判断：若时间到了强制出价时间，则强制提交
             String jude_time = DateTime.Now.ToString("hh:mm:ss");

             if (jude_time.Equals(this.textBox2.Text.ToString()))
             {
                 //MessageBox.Show("time is now !!!!" + jude_time);
                  if (!b_force_send_price)
                 {
                     btn_sendprice_click();
                     b_force_send_price = true;
                     this.label2.Text = "强制出价！！！！";
                     this.label2.Show();
                  }
             }
         } */


        private void button1_Click(object sender, EventArgs e)
        {
            VerificationNumDlg vdlg = new VerificationNumDlg();
            vdlg.ShowDialog();
        }
        public void btn_sendprice_click()
        {
            int x = 0;
            int y = 0;

            x = Properties.Settings.Default.xhook;
            y = Properties.Settings.Default.yhook;

            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
        }

        //static   Boolean fixedPriced = false;
        //static string str_fixedPrice = "";


        /*配套自动加价使用*/
        public void sendPriceCommd2()
        {
            int x, y;

            x = Properties.Settings.Default.x1;
            y = Properties.Settings.Default.y1;

            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

            Thread.Sleep(10);
            x = Properties.Settings.Default.x2;
            y = Properties.Settings.Default.y2;
            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

        }

        public void sendPriceCommd()
        {
            int x = 0;
            int y = 0;

            x = Properties.Settings.Default.x1;
            y = Properties.Settings.Default.y1;

            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

            Thread.Sleep(10);
            x = Properties.Settings.Default.x2;
            y = Properties.Settings.Default.y2;
            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            sendPriceCommd();
            /*get the  price which will be sended  */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = 730;
            int y = 472;
            SetCursorPos(x, y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            /*
            HookTestWinForm  htw = new HookTestWinForm();
            htw.Show();
            */
            global.gf_work = true;

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (b_force_send_price == true)
                b_force_send_price = false;
            global.yzm_flag = false;
            autoSubmit = false;
            subMitReason.Text = "";
            textFPrice.Text = "";
        }



        //  private tessnet2.Tesseract ocr = new tessnet2.Tesseract();//声明一个OCR类  


        //程序开始的时候，初始化OCR  
        //private void  initilOCR()
        // {   
        //      ocr.SetVariable("tessedit_char_whitelist", "0123456789."); //设置识别变量，当前只能识别数字。  
        //tesseract-2.00.eng.tar.gz 
        //  ocr.Init(@"D:\tessdata", "eng", false); //应用当前语言包。注，Tessnet2是支持多国语的。语言包下载链接：http://code.google.com/p/tesseract-ocr/downloads/list  
        //  }

        //下边这个函数是将网络上的图片识别成字符串，传入图片的超链接，输出字符串  

        /*
       public string Bmp2Str(string bmpurl)  
  
        {  
        ////http://www.newwhy.com/2010/0910/13708.html  
            string s = "0";  
            WebClient wc = new WebClient();  
            try  
            {  
                byte[] oimg = wc.DownloadData(bmpurl);//将要识别的图像下载下来  
                MemoryStream ms = new MemoryStream(oimg);  
                Bitmap image = new Bitmap(ms);  
  
  
                //为了提高识别率，所以对图片进行简单的处理  
                image = BlackAndWhite(image, 0.8);//黑白处理，这个函数看下边  
                image = new Bitmap(image, image.Width * 3, image.Height * 3);//放大三倍  
                  
                Monitor.Enter(this);//因为是多线程，所以用到了Monitor。  
                System.Collections.Generic.List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);//执行识别操作  
                foreach (tessnet2.Word word in result) //遍历识别结果。  
                    s = s + word.Text;  
                Monitor.Exit(this);  
                if (s.Length > 2)  
                    s = s.Substring(2, s.Length - 2);  
  
            }  
            catch  
            {  
                s = "0";  
           }  
           finally  
            {  
               wc.Dispose();  
            }  
           return s;  
    
        }  
  */
        //黑白处理的函数，网上查的。  

        public static Bitmap BlackAndWhite(Bitmap bitmap, Double hsb)
        {
            if (bitmap == null)
            {
                return null;
            }


            int width = bitmap.Width;
            int height = bitmap.Height;
            try
            {
                Bitmap bmpReturn = new Bitmap(width, height, PixelFormat.Format1bppIndexed);
                BitmapData srcBits = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData targetBits = bmpReturn.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed);


                unsafe
                {
                    byte* pSrcBits = (byte*)srcBits.Scan0.ToPointer();
                    for (int h = 0; h < height; h++)
                    {
                        byte[] scan = new byte[(width + 7) / 8];
                        for (int w = 0; w < width; w++)
                        {
                            int r, g, b;
                            r = pSrcBits[2];
                            g = pSrcBits[1];
                            b = pSrcBits[0];


                            if (GetBrightness(r, g, b) >= hsb) scan[w / 8] |= (byte)(0x80 >> (w % 8));
                            pSrcBits += 3;
                        }
                        Marshal.Copy(scan, 0, (IntPtr)((int)targetBits.Scan0 + targetBits.Stride * h), scan.Length);
                        pSrcBits += srcBits.Stride - width * 3;
                    }
                    bmpReturn.UnlockBits(targetBits);
                    bitmap.UnlockBits(srcBits);
                    return bmpReturn;
                }
            }
            catch
            {
                return null;
            }


        }

        private static float GetBrightness(int r, int g, int b)
        {
            float fR = ((float)r) / 255f;
            float fG = ((float)g) / 255f;
            float fB = ((float)b) / 255f;
            float fMax = fR;
            float fMin = fR;

            fMax = (fG > fMax) ? fG : fMax;
            fMax = (fB > fMax) ? fB : fMax;

            fMin = (fG < fMax) ? fG : fMax;
            fMin = (fB < fMax) ? fB : fMax;

            return ((fMax + fMin) / 2f);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Timers.Timer t = new System.Timers.Timer(200);   //实例化Timer类，设置间隔时间为毫秒；   
            t.Elapsed += new System.Timers.ElapsedEventHandler(Ocr); //到达时间的时候执行事件；   
            t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件； 

            // Ocr();
        }
        /* old  one 
        private void  Ocr0(object sender, EventArgs e)
        {
            //OcrUtil ocrUtil = new OcrUtil();
            String strPrice = ocrUtil.OcrBitmap(ocrUtil.getGrayPriceBit());
            //Thread.Sleep(10);
            String strMM = ocrUtil.OcrBitmap(ocrUtil.getGrayMMBit());
            //Thread.Sleep(10);
            String strSS = ocrUtil.OcrBitmap(ocrUtil.getGraySSBit());
            //Thread.Sleep(10);
            textPrice.Text = strPrice;
            textMM.Text = strMM;
            textSS.Text = strSS;

            this.textBox1.Text = Control.MousePosition.X.ToString() + " | " +
            Control.MousePosition.Y.ToString();
          
        }
        */
        private void Ocr(object sender, EventArgs e)
        {
            Bitmap bit_price = ocrUtil.getGrayPriceBit(false);
            Bitmap bit_time = ocrUtil.getHHMMSSBit();
            Bitmap bit_myPrice = ocrUtil.getMyPriceBit();


            /*show the picture of the price  */

            this.lowest_pict_Box.Image = (Image)bit_price.Clone();
            this.time_pic_Box.Image = (Image)bit_time.Clone();
            this.my_price_pictureBox.Image = (Image)bit_myPrice.Clone();

            String strPrice = ocrUtil.OcrBitmap(bit_price);
            String strHHMMSS = ocrUtil.OcrBitmap(bit_time);
            String strMyPrice = ocrUtil.OcrBitmap(bit_myPrice);

            textPrice.Text = strPrice;
            this.time_textBox.Text = strHHMMSS;

            if (strHHMMSS == null || strHHMMSS.Length < 9)
                return;

            /*11029011*/
            String strMM = strHHMMSS.Substring(3, 2);
            String strSS = strHHMMSS.Substring(6, 2);
            String strHH = strHHMMSS.Substring(0, 2);


            textMM.Text = strMM;
            textSS.Text = strSS;
            textHH.Text = strHH;

            textFPrice.Text = strMyPrice;


            try {
                int a = Convert.ToInt32(textPrice.Text.ToString());
                int b = a + 300;
                HightPriceText.Text = b.ToString();

                
            }
            catch(Exception ee)
            {
                ee.ToString();

                //MessageBox.Show(ee.ToString());
            }


          

           // getSystemTime();

        }

        
        public  void getSystemTime()  
        {


              /*获取当前的系统时间*/
                String str_time = null;

                str_time =  DateTime.Now.ToString("hh:mm:ss");

                this.SysTimetextBox.Text = str_time;


                if (str_time != null &&  0 ==str_time.CompareTo(this.sysTimeForceSendPricetextBox.ToString()))
                {
                    textBox4.Text = "系统时间强制提交！[" + str_time + "]";
                }


        }

        private void buttontest_Click(object sender, EventArgs e)
        {
    /*           
                SetCursorPos(addedPrice_x,addedPrice_y);
                mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                Thread.Sleep(10);
                mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
                Thread.Sleep(10);
                SendKeys.Send(addPrice.Text);
      */      
        } 
       // static Boolean autoSendPriceCmd = false;
        static Boolean autoSubmit = false;
        private void BtnAutoAdd_Click(object sender, EventArgs e)
        {
            /*移动坐标至加价栏，自动输入加价addPrice.Text数值，并点击鼠标加价*/
           /* SetCursorPos(addedPrice_x, addedPrice_y);
            mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(10);
            mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
           */
            //Thread.Sleep(10);
            sendPriceCommd2();

            b_force_send_price = true;
            autoSubmit = true;
            /*allen*/
            global.yzm_flag = true;
        }

        private  void  ClickSubmitPrice()
        {
                 int x ,y =0;
                x = Properties.Settings.Default.xhook;
                y = Properties.Settings.Default.yhook; 
                 
                SetCursorPos(x,y);
                mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                Thread.Sleep(10);
                mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);
        }
        static string logtxt;

        private void SendPricetimer_Tick(object sender, EventArgs e)
        {

            this.getSystemTime();


            /*提前 n*100出价 */
            int  forwordInternalPrice = 0;
            int int_delaySeconds = 0;
            int  currentPrice  = 0 ;// Convert.ToInt32 (this.textPrice.Text);
            int  tobeSendPrice = 0 ; // Convert.ToInt32(textFPrice.Text );

 
            if (autoSubmit == true && global.yzm_flag == true)
            {
                try
                {
                    forwordInternalPrice = Convert.ToInt32(ForwordInternalPrice.Text.ToString());
                    currentPrice = Convert.ToInt32(this.textPrice.Text.ToString());
                    tobeSendPrice = Convert.ToInt32(textFPrice.Text.ToString());
                    

                    this.subMitReason.Text =
                        "|提前|" +  ForwordInternalPrice.Text.ToString() 
                        + "|最低成交|" + this.textPrice.Text.ToString() 
                          + "|提交价格| " + textFPrice.Text.ToString();
                    

                    if (currentPrice + forwordInternalPrice + 300 == tobeSendPrice)
                    {
                        //Thread.Sleep(Convert.ToInt32(delaySeconds.Text.ToString()));
                        if (delaySeconds != null && int.TryParse(delaySeconds.ToString(), out int_delaySeconds))
                        {
                            // Thread.Sleep(Convert.ToInt32(delaySeconds.Text.ToString()));
                            Thread.Sleep(int_delaySeconds);
                        }

                        logtxt = this.subMitReason.Text;
                        ClickSubmitPrice();
                        autoSubmit = false;
                        b_force_send_price = false;
                        subMitReason.Text = "提前出价："+ this.subMitReason.Text;
                        Log.Text = logtxt;
                    }

                }
                catch (Exception ee)
                {
                    ee.ToString();
                }
                
                
            }
            
            if (b_force_send_price == true && global.yzm_flag == true)
            { 
                /*判断是否
                 * 到达提交时间？ */
                String  pic_time_str = textHH.Text.ToString() +  ":" + textMM.Text.ToString()+ ":" + textSS.Text.ToString();
               
                textBox3.Text = pic_time_str;
               

                String  force_time  = textBox2.Text;
                if (pic_time_str  == null || force_time == null)
                    return;

                pic_time_str = pic_time_str.Trim().Replace("\n", "").Replace(" ","").Replace("\t","").Replace("\r","");
                force_time = force_time.Trim().Replace("\n", "").Replace(" ","").Replace("\t","").Replace("\r","");   
                

                if (pic_time_str.Equals(force_time)) 
                {
                   
                     textBox3.Text = "Time is up";
                   
                     ClickSubmitPrice();
                     autoSubmit = false;
                     b_force_send_price = false;
                     subMitReason.Text = "强制提交："+ this.subMitReason.Text;
                }
               
                
            }

            if (autoPriceDetector(textHH.Text.ToString() + ":" + textMM.Text.ToString() + ":" + textSS.Text.ToString(),
                 this.textFPrice.Text.ToString(), this.textPrice.Text.ToString()))
            {
                this.tAutoDetectorextBox.Text = "自动检测价格！重新提交";
            }

        }

        private Boolean autoPriceDetector(String  currentTime, String  submitingPrice , String currentPrice )
        {

            try
            {
                String detectTime = Properties.Settings.Default.autodetectHHMMSS;
                String detectPriceDis = Properties.Settings.Default.autodetectPriceDistance;

                if (String.Compare(currentTime, detectTime) > 0)
                {
                    if (String.Compare(submitingPrice, currentPrice) >= Convert.ToInt32(detectPriceDis))
                    {
                        
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                this.tAutoDetectorextBox.Text = e.ToString(); 

            }

            return false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            ocrUtil.testOcrTesseract();

        }

       

       

        private void button4_Click_1(object sender, EventArgs e)
        {
            ocrUtil.testOcrTesseract();
        }


        /// <summary>
        /// /////////
        /// </summary>
        /// 
            MouseHook mouseHook = new MouseHook();
            KeyboardHook keyboardHook = new KeyboardHook();
         
            private void HookTestWinForm_Load(object sender, EventArgs e)
            {

                mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
                //mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
                //mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);
                //mouseHook.MouseWheel += new MouseEventHandler(mouseHook_MouseWheel);

                keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
                keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);
                keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);

                mouseHook.Start();
                keyboardHook.Start();

                SetXYLabel(MouseSimulator.X, MouseSimulator.Y);

            }

            void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
            {

                AddKeyboardEvent(
                    "KeyPress",
                    "",
                    e.KeyChar.ToString(),
                    "",
                    "",
                    ""
                    );

            }

            void keyboardHook_KeyUp(object sender, KeyEventArgs e)
            {

                AddKeyboardEvent(
                    "KeyUp",
                    e.KeyCode.ToString(),
                    "",
                    e.Shift.ToString(),
                    e.Alt.ToString(),
                    e.Control.ToString()
                    );

            }

            void keyboardHook_KeyDown(object sender, KeyEventArgs e)
            {


                AddKeyboardEvent(
                    "KeyDown",
                    e.KeyCode.ToString(),
                    "",
                    e.Shift.ToString(),
                    e.Alt.ToString(),
                    e.Control.ToString()
                    );

            }

            void mouseHook_MouseWheel(object sender, MouseEventArgs e)
            {

                AddMouseEvent(
                    "MouseWheel",
                    "",
                    "",
                    "",
                    e.Delta.ToString()
                    );

            }

            void mouseHook_MouseUp(object sender, MouseEventArgs e)
            {


                AddMouseEvent(
                    "MouseUp",
                    e.Button.ToString(),
                    e.X.ToString(),
                    e.Y.ToString(),
                    ""
                    );

            }

            void mouseHook_MouseDown(object sender, MouseEventArgs e)
            {


                AddMouseEvent(
                    "MouseDown",
                    e.Button.ToString(),
                    e.X.ToString(),
                    e.Y.ToString(),
                    ""
                    );


            }

            void mouseHook_MouseMove(object sender, MouseEventArgs e)
            {

                SetXYLabel(e.X, e.Y);

            }

            void SetXYLabel(int x, int y)
            {

                curXYLabel.Text = String.Format("X={0}, y={1}", x, y);

            }

            void AddMouseEvent(string eventType, string button, string x, string y, string delta)
            {

                /*
                 listView1.Items.Insert(0,
                    new ListViewItem(
                        new string[]{
                        eventType,
                        button,
                        x,
                        y,
                        delta
                        }));
              */
            }

            void AddKeyboardEvent(string eventType, string keyCode, string keyChar, string shift, string alt, string control)
            {

                /* listView2.Items.Insert(0,
                     new ListViewItem(
                         new string[]{
                        eventType,
                        keyCode,
                        keyChar,
                        shift,
                        alt,
                        control
                    }));*/ 

                if (keyCode == Keys.Enter.ToString()   && global.gf_work)
                {
                    int x, y = 0;
                    //x = 777;
                    //y = 500;

                    x = Properties.Settings.Default.xhook;
                    y = Properties.Settings.Default.yhook;

                    SetCursorPos(x, y);
                    mouse_event(MouseEventFlag.LeftDown, 0, 0, 0, UIntPtr.Zero);
                    Thread.Sleep(10);
                    mouse_event(MouseEventFlag.LeftUp, 0, 0, 0, UIntPtr.Zero);

                }
                if (keyCode == Keys.Add.ToString() &&  global.gf_work )
                {
                    global.yzm_flag = true; ;

                }
                if (keyCode == Keys.OemMinus.ToString() && global.gf_work)
                {
                    global.yzm_flag = true; ;

                }

            }

        private void button5_Click(object sender, EventArgs e)
        {
            global.gf_work = false;
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            ocrUtil.testOcrTesseract2();
        }
    }
}
