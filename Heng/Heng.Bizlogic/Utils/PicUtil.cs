using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Heng.Bizlogic.Utils
{
    public class PicUtil
    {


        public static Bitmap GetScreen()
        {
            //获取整个屏幕图像,不包括任务栏
            Bitmap bmp = new Bitmap(1920, 1080);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(1920, 1080));
            }
            System.GC.Collect();
            return bmp;
        }

        public static Bitmap GetScreen(int sourceX, int sourceY, int width, int height)
        {
            //获取整个屏幕图像,不包括任务栏
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(sourceX, sourceY, 0, 0, new Size(width, height));
            }
            System.GC.Collect();
            return bmp;
        }

        /// <summary> 
        /// 放大缩小图片尺寸 
        /// </summary> 
        /// <param name="picPath"></param> 
        /// <param name="reSizePicPath"></param> 
        /// <param name="iSize"></param> 
        /// <param name="format"></param> 
        public static Bitmap PicSized(Bitmap originBmp, int iSize)
        {
            int w = originBmp.Width * iSize;
            int h = originBmp.Height * iSize;
            Bitmap resizedBmp = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(resizedBmp);
            //设置高质量插值法   
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度   
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //消除锯齿 
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(originBmp, new Rectangle(0, 0, w, h), new Rectangle(0, 0, originBmp.Width, originBmp.Height), GraphicsUnit.Pixel);
            g.Dispose();
            return resizedBmp;
        }

        public static JObject BaiDuOCR(Bitmap bm)
        {
            // 设置APPID/AK/SK
            var APP_ID = Singleton.GetInstance().APP_ID;
            var API_KEY = Singleton.GetInstance().API_KEY;
            var SECRET_KEY = Singleton.GetInstance().SECRET_KEY;
            var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间
            var image = Bitmap2Byte(bm);
            // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.GeneralBasic(image);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                    {"language_type", "CHN_ENG"},
                    {"detect_direction", "true"},
                    {"detect_language", "true"},
                    {"probability", "true"}
                };
            // 带参数调用通用文字识别, 图片参数为本地图片
            JObject j = client.GeneralBasic(image, options);
            return j;
        }

        public static JObject BaiDuOCR(string fileName)
        {
            // 设置APPID/AK/SK
            var APP_ID = Singleton.GetInstance().APP_ID;
            var API_KEY = Singleton.GetInstance().API_KEY;
            var SECRET_KEY = Singleton.GetInstance().SECRET_KEY;
            var client = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            client.Timeout = 3000;  // 修改超时时间
            var image = File.ReadAllBytes(fileName);
            // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
            var result = client.GeneralBasic(image);
            // 如果有可选参数
            var options = new Dictionary<string, object>{
                    {"language_type", "CHN_ENG"},
                    {"detect_direction", "true"},
                    {"detect_language", "true"},
                    {"probability", "true"}
                };
            // 带参数调用通用文字识别, 图片参数为本地图片
            JObject j = client.GeneralBasic(image, options);
            return j;

        }


        public static byte[] Bitmap2Byte(Bitmap bitmap)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                byte[] data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
                return data;
            }
        }

        private static byte[] convertByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, img.RawFormat);
            //byte[] bytes = new byte[ms.Length];  
            //ms.Read(bytes, 0, Convert.ToInt32(ms.Length));  
            //以上两句改成下面两句  
            byte[] bytes = ms.ToArray();
            ms.Close();
            return bytes;
        }
        private static Image ConvertImg(byte[] datas)
        {
            MemoryStream ms = new MemoryStream(datas);
            Image img = Image.FromStream(ms, true);//在这里出错  
                                                   //流用完要及时关闭  
            ms.Close();
            return img;
        }

     
        /// <summary>
        /// Convert Image to Byte[]
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                if (format.Equals(ImageFormat.Jpeg))
                {
                    image.Save(ms, ImageFormat.Jpeg);
                }
                else if (format.Equals(ImageFormat.Png))
                {
                    image.Save(ms, ImageFormat.Png);
                }
                else if (format.Equals(ImageFormat.Bmp))
                {
                    image.Save(ms, ImageFormat.Bmp);
                }
                else if (format.Equals(ImageFormat.Gif))
                {
                    image.Save(ms, ImageFormat.Gif);
                }
                else if (format.Equals(ImageFormat.Icon))
                {
                    image.Save(ms, ImageFormat.Icon);
                }
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }



        #region 从大图中截取一部分图片
        /// <summary>
        /// 从大图中截取一部分图片
        /// </summary>
        /// <param name="fromImagePath">来源图片地址</param>        
        /// <param name="offsetX">从偏移X坐标位置开始截取</param>
        /// <param name="offsetY">从偏移Y坐标位置开始截取</param>
        /// <param name="toImagePath">保存图片地址</param>
        /// <param name="width">保存图片的宽度</param>
        /// <param name="height">保存图片的高度</param>
        /// <returns></returns>
        public static Bitmap CaptureImage(Bitmap bm, Point point, int width, int height)
        {
            //40,35
            Image img = ConvertImg(Bitmap2Byte(bm));
            Bitmap bitmap = new Bitmap(width, height);
            //创建作图区域
            Graphics graphic = Graphics.FromImage(bitmap);
            //截取原图相应区域写入作图区
            int x = point.X;
            int y = point.Y;
            graphic.DrawImage(img,0, 0, new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            //释放资源   
            Bitmap bm2 = new Bitmap(saveImage);
            saveImage.Dispose();
            graphic.Dispose();
            bitmap.Dispose();
            return bm2;
        }


        /// <summary>
        /// 图片中保留needColor
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="needColor"></param>
        /// <returns></returns>
        public static Bitmap ChangeColor(Bitmap bmp,Color needColor)
        {
            LockBitmap lockbmp = new LockBitmap(bmp);
            //锁定Bitmap，通过Pixel访问颜色
            lockbmp.LockBits();
            //获取颜色
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color color = lockbmp.GetPixel(i, j);
                    //Color.FromArgb(255, 255, 0)
                    if (!color.Equals(needColor))
                    {
                        lockbmp.SetPixel(i, j, Color.Black);
                    }
                }
            }
            //从内存解锁Bitmap
            lockbmp.UnlockBits();
            return bmp;
        }

     


        #endregion

    }
}
