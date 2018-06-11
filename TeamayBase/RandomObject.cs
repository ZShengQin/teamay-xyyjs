using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;


namespace TeamayBase
{
    /// <summary>
    /// 随机函数
    /// </summary>
    public class RandomObject
    {
        private static int rep = 0;

        #region 数字随机数
        /// <summary>
        /// 数字随机数
        /// </summary>
        /// <param name="n">生成长度</param>
        /// <returns></returns>
        public static string RandNum(int codeCount)
        {
            string str = string.Empty;
            long num2 = DateTime.Now.Ticks + rep;
            rep++;
            Random random = new Random(((int)(((ulong)num2) & 0xffffffffL)) | ((int)(num2 >> rep)));
            for (int i = 0; i < codeCount; i++)
            {
                int num = random.Next();
                str = str + ((char)(0x30 + ((ushort)(num % 10)))).ToString();
            }
            return str;
        }
        #endregion
    }
}
