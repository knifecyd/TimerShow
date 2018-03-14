using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using MouseKeyboardLibrary;

using System.Runtime.InteropServices;
using Tesseract;

namespace TimerShow
{

    class OcrUtil
    {

        /*price_point_x1,x2,y1,y2-  当前可成交价格位置*/
        /*hhmmss_point_x1,x2,y1,y2- 当前时间*/
        /*xhook  yhook -  回车提交快捷键位置*/


        Point price_point = new Point(Properties.Settings.Default.price_point_x1, Properties.Settings.Default.price_point_y1);
        //int price_point_with = Properties.Settings.Default.price_point_x2 - Properties.Settings.Default.price_point_x1;
        //int price_point_heigh = Properties.Settings.Default.price_point_y2 - Properties.Settings.Default.price_point_y1;

        Point ss_point = new Point(Properties.Settings.Default.ss_point_x1, Properties.Settings.Default.ss_point_y1);
        int ss_point_with = Properties.Settings.Default.ss_point_x2 - Properties.Settings.Default.ss_point_x1;
        int ss_point_heigh = Properties.Settings.Default.ss_point_y2 - Properties.Settings.Default.ss_point_y1;
        Point mm_point = new Point(Properties.Settings.Default.mm_point_x1, Properties.Settings.Default.mm_point_y1);
        int mm_point_with = Properties.Settings.Default.mm_point_x2 - Properties.Settings.Default.mm_point_x1;
        int mm_point_heigh = Properties.Settings.Default.mm_point_y2 - Properties.Settings.Default.mm_point_y1;

        Point hhmmss_point = new Point(Properties.Settings.Default.hhmmss_point_x1, Properties.Settings.Default.hhmmss_point_y1);
        //int hhmmss_point_with = Properties.Settings.Default.hhmmss_point_x2 - Properties.Settings.Default.hhmmss_point_x1;
        //int hhmmss_point_heigh = Properties.Settings.Default.hhmmss_point_y2 - Properties.Settings.Default.hhmmss_point_y1;


        Point myPrice_point = new Point(Properties.Settings.Default.my_price_x1, Properties.Settings.Default.my_price_y1);
        //int myPrice_point_with = Properties.Settings.Default.my_price_x2 - Properties.Settings.Default.my_price_x1;
        //int myPrice_point_heigh = Properties.Settings.Default.my_price_y2 - Properties.Settings.Default.my_price_y1;


        int price_point_with = Properties.Settings.Default.price_point_L;
        int price_point_heigh = Properties.Settings.Default.price_point_H;
        int hhmmss_point_with = Properties.Settings.Default.hhmmss_point_L;
        int hhmmss_point_heigh = Properties.Settings.Default.hhmmss_point_H;
        int myPrice_point_with = Properties.Settings.Default.my_price_L;
        int myPrice_point_heigh = Properties.Settings.Default.my_price_H;
        



        //带验证码的 
        Point fprice_point = new Point(Properties.Settings.Default.fprice_point_x1, Properties.Settings.Default.fprice_point_y1);
        int fprice_point_with = Properties.Settings.Default.fprice_point_x2 - Properties.Settings.Default.fprice_point_x1;
        int fprice_point_heigh = Properties.Settings.Default.fprice_point_y2 - Properties.Settings.Default.fprice_point_y1;

        //ocr 类
        TesseractEngine engine; // = new TesseractEngine(@"../tessdata", "fontyp", EngineMode.TesseractOnly);



        /* 
        tesseract 586.JPG res  -psm 7 digits
        tesseract 234.tif 234.exp0 -l eng -psm 7 batch.nochop makebox 
        tesseract p1.tif p1.exp1 -l eng -psm 7 nobatch box.train 
        unicharset_extractor cyd.fontyp.p1.box
        unicharset_extractor p1.box

         */

        public OcrUtil()
        {
            engine  = new TesseractEngine(@"tessdata", "fontyp", EngineMode.TesseractOnly);
            engine.SetVariable("tessedit_char_whitelist", "0123456789:");

        }

        public void saveImageFile(Bitmap gryBit, string filename)
        {
            gryBit.Save(filename + ".tif", System.Drawing.Imaging.ImageFormat.Tiff);
              
        }
        public static byte[] BitmapToBytes(Bitmap bitmap)
        {
            if (bitmap == null)
            {
                MessageBox.Show("Bitmap is  null ");
                return new byte[20];
            }
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                bitmap.Save(ms, bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                ms.Close();
            }
        }

        public string ocrByBitmap(Bitmap b)
        {

            //this.saveImageFile(b, Convert.ToInt64((DateTime.UtcNow - new DateTime(1970,1,1,0,0,0,0)).TotalSeconds).ToString());

            //TesseractEngine engine = new TesseractEngine(@"../tessdata", "fontyp", EngineMode.TesseractOnly);

            Pix img;
            Page page; 
            try
            {
                img = PixConverter.ToPix(b);

                page = engine.Process(img);

                string text = page.GetText();

                page.Dispose();

                return text.ToString();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            
        }


        public  void  testOcrTesseract()
        {
           TesseractEngine engine = new TesseractEngine(@"../tessdata", "fontyp", EngineMode.TesseractOnly);
          
            try
            {
                 
                    engine.SetVariable("tessedit_char_whitelist", "0123456789");
                    using (var img = Pix.LoadFromFile("../90400.jpg"))
                    {

                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            MessageBox.Show(text);
                        }
                    }
                
            }
            catch (Exception ex)
            {
                 
              MessageBox.Show(ex.ToString());
            }
        }

        public void testOcrTesseract2()
        {
            TesseractEngine engine = new TesseractEngine(@"../tessdata", "fontyp", EngineMode.TesseractOnly);
            Bitmap bit_time = getHHMMSSBit();
            Bitmap price_bit_time = this.getGrayPriceBit();

            System.Drawing.Bitmap img1 = bit_time;
            System.Drawing.Bitmap img2 = price_bit_time;

            UnCodebase ud = new UnCodebase(img1);
            UnCodebase ud2 = new UnCodebase(img2);


            img1 = ud.GrayByPixels();
            img2 = ud2.GrayByPixels();

            // ud.ClearNoise(128, 2);
            string str = System.Environment.CurrentDirectory;

            Bitmap gryBit = img1;
            String grybitFileNm = str + "\\HHMMSSBit" +DateTime.Now.ToLongDateString() + ".tif";
            gryBit.Save(grybitFileNm, System.Drawing.Imaging.ImageFormat.Tiff);

            Bitmap gryBit2 = img2;
            String grybitFileNm2 = str + "\\price_bit_time" + DateTime.Now.ToLongDateString() + ".tif";
            gryBit2.Save(grybitFileNm2, System.Drawing.Imaging.ImageFormat.Tiff);



            var img = PixConverter.ToPix(bit_time);


            try
            {

                engine.SetVariable("tessedit_char_whitelist", "0123456789");
                //using (var img = Pix.LoadFromFile("../90400.jpg"))
                {

                    using (var page = engine.Process(img))
                    {
                        var text = page.GetText();
                        MessageBox.Show(text);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        /*
         * 
         * https://stackoverflow.com/questions/38336601/ocr-tesseractengine
         * / 
        public Bitmap ScaleByPercent(Bitmap imgPhoto, int Percent)
    {
        float nPercent = ((float)Percent / 100);

        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        var destWidth = (int)(sourceWidth * nPercent);
        var destHeight = (int)(sourceHeight * nPercent);

        var bmPhoto = new Bitmap(destWidth, destHeight,
                                 PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                              imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
                          new System.Drawing.Rectangle(0, 0, destWidth, destHeight),
                          new System.Drawing.Rectangle(0, 0, sourceWidth, sourceHeight),
                          GraphicsUnit.Pixel);
        bmPhoto.Save(@"D:\Scale.png", System.Drawing.Imaging.ImageFormat.Png);
        grPhoto.Dispose();
        return bmPhoto;
    } 
            
        /*
         * 
         * https://stackoverflow.com/questions/38336601/ocr-tesseractengine
         *  Strickos9 had shown you a partially great way to solve this issue. 
         *  But the point is that if you will have to scan text with the same size, 
         *  but also there would be some letters included, you will get a bad result. 
         *  Also, even with whitelist related only to digits, 
         *  you may expierence some problems while scanning 
         *  (for example 5 scanned as 6), because Tesseract really struggles 
         *  to scan a low quality characters, 
         *  so I would highly recommend you to:
         *  Enlarge the image by 2-4 times.
         *  Do some blur if needed to soften the edges of chars.
         *  Process it with 'threshold' or 'adaptive threshold' algorythms 
         *  (to clear the blurred pixels and that blue color in the background).
         *  I've answered a similar question HERE, where a person 
         *  was also unsatisfied with results 
         *  while scanning a low quality picture.
         *  Combined with what Strickos9 offered to you 
         *  (if you are going to scan only digits) should provide you a perfect quality of scanning.
         *  You can do this image processing with software like OpenCV or
         *  Matlab (although I've never tried this). 
         *  If you are struggling with this, post in comments your further questions.
         */

        Bitmap GrayBitmapSimply(Bitmap b)
        { 
            Bitmap bitmap = (Bitmap)b.Clone();
            UnCodebase ud = new UnCodebase(bitmap);
            bitmap = ud.GrayByPixels();
            bitmap = ud.ReSetBitMap();
            return bitmap;
        
        }
        public Bitmap getGrayFinalPriceBit()
        {
            Image baseImage = new Bitmap(fprice_point_with, fprice_point_heigh);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(price_point, new Point(0, 0), new Size(fprice_point_with, fprice_point_heigh));
            g.Dispose();
            Bitmap gray_bitmap = this.GrayBitmapSimply((Bitmap)baseImage);
            return gray_bitmap;

        }


        public Image CombinImage(Image sourceImg, Image destImg)
        {
            Graphics g = Graphics.FromImage(sourceImg);
            g.DrawImage(sourceImg, 0, 0, sourceImg.Width, sourceImg.Height);      // g.DrawImage(imgBack, 0, 0, 相框宽, 相框高); 
            //g.FillRectangle(System.Drawing.Brushes.Black, 16, 16, (int)112 + 2, ((int)73 + 2));//相片四周刷一层黑色边框

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);
            g.DrawImage(destImg, 0 + sourceImg.Width, sourceImg.Height, destImg.Width, destImg.Height);
            GC.Collect();
            return sourceImg;
        }

         

        public Bitmap getGrayPriceBit( Boolean  old_type = false )
        {
                Bitmap gray_bitmap = null;
                Image baseImage = new Bitmap(price_point_with, price_point_heigh);
                Graphics g = Graphics.FromImage(baseImage);
                g.CopyFromScreen(price_point, new Point(0, 0), new Size(price_point_with, price_point_heigh));
                g.Dispose();
                /*不需要再转灰度处理*/    
                if(old_type == true )
                     gray_bitmap = this.GrayBitmapSimply((Bitmap)baseImage);
                else
                     gray_bitmap = (Bitmap)baseImage;


                return gray_bitmap;
           
        }

        public Bitmap getHHMMSSBit()
        {
            Image baseImage = new Bitmap(hhmmss_point_with, hhmmss_point_heigh);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(hhmmss_point, new Point(0, 0), new Size(hhmmss_point_with, hhmmss_point_heigh));
            g.Dispose();             
            return (Bitmap)baseImage;
        }


        public Bitmap getMyPriceBit()
        {
            Image baseImage = new Bitmap(myPrice_point_with, myPrice_point_heigh);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(myPrice_point, new Point(0, 0), new Size(myPrice_point_with, myPrice_point_heigh));
            g.Dispose();
            return (Bitmap)baseImage;
        }




        public Bitmap getGraySSBit()
        {
            Image baseImage = new Bitmap(ss_point_with, ss_point_heigh);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(ss_point, new Point(0, 0), new Size(ss_point_with, ss_point_heigh));
            g.Dispose();
            Bitmap gray_bitmap = this.GrayBitmapSimply((Bitmap)baseImage);
            return gray_bitmap;

        }

        public Bitmap getGrayMMBit()
        {
            Image baseImage = new Bitmap(mm_point_with, mm_point_heigh);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(mm_point, new Point(0, 0), new Size(mm_point_with, mm_point_heigh));
            g.Dispose();
            Bitmap gray_bitmap = this.GrayBitmapSimply((Bitmap)baseImage);
            return gray_bitmap;

        }



        public Bitmap getGraymmBit()
        {
            Image baseImage = new Bitmap(price_point_with, price_point_heigh);
            Graphics g = Graphics.FromImage(baseImage);
            g.CopyFromScreen(price_point, new Point(0, 0), new Size(price_point_with, price_point_heigh));
            g.Dispose();
            Bitmap gray_bitmap = this.GrayBitmapSimply((Bitmap)baseImage);
            return gray_bitmap;

        }

        public String OcrBitmap(Bitmap src)
        {
            return  this.ocrByBitmap(src);
            
        }


        public String OcrBitmap_old_one(Bitmap src)
        {
              
            System.Drawing.Bitmap img = src;

            UnCodebase ud = new UnCodebase(img);
            img = ud.GrayByPixels();
            ud.ClearNoise(128, 2);
            string str = System.Environment.CurrentDirectory;

            Bitmap gryBit = img;
            String grybitFileNm = str + "\\gybit" + ".tif";
            gryBit.Save(grybitFileNm, System.Drawing.Imaging.ImageFormat.Tiff);


            System.Diagnostics.Process exep = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "tesseract.exe";

            startInfo.Arguments = "" +
            grybitFileNm
            + "  output -l fontyp -psm 7";

            //MessageBox.Show(startInfo.Arguments);

            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            exep.StartInfo = startInfo;
            exep.Start();
            exep.WaitForExit();
            
            FileStream fs = File.OpenRead(str + "\\output.txt");
            int filelength = 0;
            fs.Seek(0, SeekOrigin.Begin);

            filelength = (int)fs.Length; //获得文件长度 
            Byte[] image = new Byte[filelength]; //建立一个字节数组 
            char[] charData = new char[filelength];

            fs.Read(image, 0, filelength); //按字节流读取 

            Decoder d = Encoding.Default.GetDecoder();
            d.GetChars(image, 0, image.Length, charData, 0);
            Console.WriteLine(charData);

            fs.Close();
            String str_res = new String(charData);
            return str_res;
             
        }   
        public void PriceOcrBtn_Click(object sender, EventArgs e)
        {

            System.Timers.Timer t = new System.Timers.Timer(100);   //实例化Timer类，设置间隔时间为10000毫秒；   
            t.Elapsed += new System.Timers.ElapsedEventHandler(testc); //到达时间的时候执行事件；   
            t.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            t.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
        }

        public void testc(object source, System.Timers.ElapsedEventArgs e)
        {
            String str = OcrBitmap(getGrayPriceBit());
           // pricetextBox.Text = str;
        }
        
    }

     }

    public class Consts
    {
        public static string[] ArrCode()
        {
            string[] a = new string[] {   "00100000000000000000000000000000000000000000000000000000000000000000000011100000000000001111011110000000001111110001110000000111000000001100000011000000000011000001100000000000110000011000000000011000000110000000111110000001110001101110000000001111111100000000"//0                                         
                                        ,"00000000000000000000000000000000000000000000000000000000000000000000000000000000000000100000000000000000011000000000000000001100000000000000000111011111100000000001111111010111100000111100000001011000001000000000000000000000000000000000000000000000000000000000"//1
                                        ,"00000000000000000000000000000000000000000000000000000000000000000000000000100000000000000000111100000001100000011011000000111000000100110000011000000011001100000110000001100011000001100000110000110000011000001000001100000111011100000011000000111110000000010000"//2
                                        ,"00000000000000000000000000000000000000000000010000000000000000001100000001000000000110000000011000000011000000000011000000110000110000111000001100001100000110000011100111000001100000011111011000011000000100000011111100000000000000011111000000000000000000100000"//3
                                        ,"00000000000000000000000000000000000000000000000000000000000000000000000011100000000000000000011000000000000000110110000000000000011001100000000000011000011000000000101100000111110000011110000011100000000001111111011000000000000000000110000000000000000000000000"//4
                                        ,"00000000000000000000000000000000000000000000000110001000000000000001100011000000000111111000011000000011110100000111000001100011000000110000011000110000001100000110001110000011000001100011110011110000011000001111111000000110000000000100000001100000000000000000"//5
                                        ,"00000000000000000000000000000000000000000000000111111000000000000011111111100000000001100110011100000000110011000001100000011000110000001000000110001100000011000001100011000000110000011000011100011100000011100011101111000000011000000111000000000000000000000000"//6
                                        ,"00001100000000000000000000000000000000000000000000000000000000000000000000000000010000000000000000000110000000000011000001100000000011110000011000000011100000000110000011110000000001100001100000000000011001110000000000000110111000000000000001111000000000000000"//7
                                        ,"00000000000000000000000000000000000000000000000000000000000000000000000000000000001110000000000000000111011001111100000001100011111111110000011000011100011100000110000110000011000001110001100000110000001110111000001100000000111010000010000000000100011011100000"//8
                                        };
            return a;

        }

    }



