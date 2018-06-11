using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using System.Web;
using System.Web.UI;

namespace TeamayBase
{
    /// <summary>
    /// ImageLogin 的摘要说明。
    /// </summary>
    public class ImageLogincs
    {
        private Bitmap validateimage;
        private Graphics g;
        private string m_validatenum;
        public string ValidateNum
        {
            get { return m_validatenum; }
        }
        public ImageLogincs(int validatelength)
        {
            string strvalidatenum = this.validatecodernd(validatelength);
            this.m_validatenum = strvalidatenum;
        }
        public ImageLogincs()
        {
        }
        public string getCode(int length)
        {
            return validatecodernd(length);
        }

        public void validatecode(string validatenum, Page page)
        {
            int gwidth = validatenum.Length * 7;//gheight为图片宽度,根据字符长度自动更改图片宽度
            validateimage = new Bitmap(gwidth, 18, PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(validateimage);
            //在矩形内绘制字串（字串，字体，画笔颜色，左上x.左上y）
            g.FillRectangle(new LinearGradientBrush(new Point(0, 0), new Point(120, 30), Color.FromKnownColor(KnownColor.White), Color.FromKnownColor(KnownColor.White)), 0, 0, 120, 30);
            g.DrawString(validatenum, new Font("宋体", 9), new SolidBrush(Color.Red), new PointF(2, 4));
            g.Save();
            MemoryStream ms = new MemoryStream();
            validateimage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            page.Response.ClearContent();
            page.Response.ContentType = "image/Jpeg";
            page.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            validateimage.Dispose();
            page.Response.End();
        }
        private string validatecodernd(int vnumlength)
        {
            string[] s = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            string num = "";
            Random r = new Random();
            for (int i = 0; i < vnumlength; i++)
            {
                num += s[r.Next(0, s.Length)].ToString();
            }
            return num;
        }

    }
}
