using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.IO;

namespace FouridStudio
{
    /// <summary>
    /// Excel操作
    /// </summary>
    public class NPOIExcel
    {
        #region 屬性

        /// <summary>
        /// Workbook物件
        /// </summary>
        private IWorkbook workbook = null;

        public NPOISheet this[string sheetName]
        {
            get
            {
                ISheet sheet = workbook.GetSheet(sheetName);

                return new NPOISheet(sheet == null ? workbook.CreateSheet(sheetName) : sheet);
            }
        }

        #endregion 屬性

        #region 主要函式

        /// <summary>
        /// 建立新的Excel
        /// </summary>
        public NPOIExcel()
        {
            workbook = new HSSFWorkbook();
        }

        /// <summary>
        /// 讀取已有的Excel
        /// </summary>
        /// <param name="path"></param>
        public NPOIExcel(string path)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                workbook = new HSSFWorkbook(fileStream);
            }
        }

        /// <summary>
        /// 儲存Excel
        /// </summary>
        /// <param name="path"></param>
        public void save(string path)
        {
            using (FileStream fileStream = File.OpenWrite(path))
            {
                workbook.Write(fileStream);
            }
        }

        #endregion 主要函式
    }

    /// <summary>
    /// Excel工作表操作
    /// </summary>
    public class NPOISheet
    {
        #region 屬性

        private ISheet sheet = null;

        public NPOICell this[int rowNumber, int cellNumber]
        {
            get
            {
                IRow row = sheet.GetRow(rowNumber);

                if (row == null)
                    row = sheet.CreateRow(rowNumber);

                ICell cell = row.GetCell(cellNumber);

                if (cell == null)
                    cell = row.CreateCell(cellNumber);

                return new NPOICell(cell);
            }
        }

        #endregion 屬性

        #region 主要函式

        public NPOISheet(ISheet sheet)
        {
            this.sheet = sheet;
        }

        #endregion 主要函式
    }

    /// <summary>
    /// Excel儲存格操作
    /// </summary>
    public class NPOICell
    {
        #region 屬性

        private ICell cell = null;

        #endregion 屬性

        #region 主要函式

        public NPOICell(ICell cell)
        {
            this.cell = cell;
        }

        public int getInteger()
        {
            return (int)cell.NumericCellValue;
        }

        public double getDouble()
        {
            return cell.NumericCellValue;
        }

        public string getString()
        {
            return cell.StringCellValue;
        }

        public DateTime getDateTime()
        {
            return cell.DateCellValue;
        }

        public void setValue(object obj)
        {
            if (obj.GetType() == typeof(int))
                cell.SetCellValue((int)obj);
            else if (obj.GetType() == typeof(double))
                cell.SetCellValue((double)obj);
            else if (obj.GetType() == typeof(string))
                cell.SetCellValue(obj.ToString());
            else if (obj.GetType() == typeof(DateTime))
                cell.SetCellValue((DateTime)obj);
            else if (obj.GetType() == typeof(bool))
                cell.SetCellValue((bool)obj);
            else
                cell.SetCellValue(obj.ToString());
        }

        #endregion 主要函式
    }
}