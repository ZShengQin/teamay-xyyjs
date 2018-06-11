
using System;
using System.Web;
using System.Web.UI;
using System.ComponentModel;
using System.Data;
using TeamayBase;

using org.in2bits.MyXls;

namespace TeamayBase
{
    public class Excel : System.Web.UI.Page
    {

        /// <summary>
        /// ���캯��
        /// </summary>
        public static void Export(string sql, string[] temp, string subject)
        {
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            #region
            XlsDocument xls = new XlsDocument();
            xls.FileName = subject + ".xls";
            //����ļ�����
            xls.SummaryInformation.Author = "Teamay"; //����
            xls.SummaryInformation.Subject = subject;
            xls.DocumentSummaryInformation.Company = "Teamay Tech";
            string sheetName = "Sheet1";
            int rowMin = 1;
            int rowCount = dt.Rows.Count + 1;
            int colMin = 1;
            int colCount = temp.Length;
            //����5�����
            Worksheet sheet = xls.Workbook.Worksheets.AddNamed(sheetName);

            Cells cells = sheet.Cells;
            for (int r = 0; r < rowCount; r++)
            {
                if (r == 0)
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        //��һ���ڴ���colCount����Ԫ��
                        //cells.Add(rowMin + r, colMin + c, "Fld" + (c + 1)).Font.Bold = true;
                        Cell cell = cells.Add(rowMin + r, colMin + c, temp[c]);
                        cell.Font.Bold = true;
                        //cell.Font.Height = 500;
                        cell.HorizontalAlignment = HorizontalAlignments.Centered;
                        cell.TextDirection = TextDirections.ByContext;
                        //cell.Type = CellTypes.Text;
                    }
                }
                else
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        Cell cell = cells.Add(rowMin + r, colMin + c, dt.Rows[r - 1][c].ToString());
                    }
                }
            }

            xls.Send();
            #endregion
        }


    }

}
