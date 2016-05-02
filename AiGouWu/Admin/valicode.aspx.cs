using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace AiGouWu
{
    public partial class valicode:System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string chcode = "";
            //颜色列表，用于验证码，噪线，躁点的绘制
            Color[] colors = { Color.Black, Color.Red, Color.Green, Color.Orange,  Color.DarkBlue };
            //字体列表，用于验证码
            string[] font = { "Times New Roman", "MS MinCho", "Book Antiqua", "Gungsuh", "PMingLiU", "Impact" };
            //验证码的字符集，去掉容易混淆的字符
            char[] Character = { '2', '3', '4', '5', '6', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            //实例化一个随机对象
            Random random = new Random();
            //随机生成验证码
            for (int i = 0; i < 4; i++)
            {
                chcode += Character[random.Next(Character.Length)];
            }

            //保存验证码 Cookie
            HttpCookie anycookie = new HttpCookie("ValidateCookie");
            anycookie.Values.Add("Chcode", chcode);
            HttpContext.Current.Response.Cookies["ValidateCookie"].Values["Chcode"] = chcode;

            Bitmap bmp = new Bitmap(100, 30);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //画噪音线
            for (int i = 0; i < 5; i++)
            {
                int x1 = random.Next(100);
                int y1 = random.Next(30);
                int x2 = random.Next(100);
                int y2 = random.Next(30);
                Color clr = colors[random.Next(colors.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);

            }
            //画验证码字符串
            for (int i = 0; i < chcode.Length; i++)
            {
                string fontsytle = font[random.Next(font.Length)];
                Font fnt = new Font(fontsytle, 16);
                Color fcolor = colors[random.Next(colors.Length)];
                g.DrawString(chcode[i].ToString(), fnt, new SolidBrush(fcolor), i * 20 + 20, 6);
            }
            //画噪点
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(bmp.Width);
                int y = random.Next(bmp.Height);
                Color fcolor = colors[random.Next(colors.Length)];
                bmp.SetPixel(x, y, fcolor);
            }

            //清除该页输出缓存，设置该页无缓存
            Response.Buffer = true;
            Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0);
            Response.Expires = 0;
            Response.CacheControl = "no-cache";
            Response.AppendHeader("Pragma", "No-Cache");

            //把验证码图片写入到内存中，并以图片格式输出（"imgae/png"）;
            MemoryStream stream = new MemoryStream();
            try
            {
                bmp.Save(stream, ImageFormat.Png);
                Response.ClearContent();
                Response.ContentType = "Image/png";
                Response.BinaryWrite(stream.ToArray());
            }
            finally
            {
                bmp.Dispose();
                g.Dispose();
               
            }

           


        }
    }
}