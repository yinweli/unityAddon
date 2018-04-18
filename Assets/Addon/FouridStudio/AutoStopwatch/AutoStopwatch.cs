using System;
using System.Diagnostics;

namespace FouridStudio
{
    /// <summary>
    /// 自動報告計時
    /// </summary>
    public class AutoStopwatch : IDisposable
    {
        #region 屬性

        /// <summary>
        /// 報告標題
        /// </summary>
        private string title = "";

        /// <summary>
        /// 計時器物件
        /// </summary>
        private Stopwatch stopWatch = new Stopwatch();

        #endregion 屬性

        #region 主要函式

        public AutoStopwatch(string title)
        {
            this.title = title;
            this.stopWatch.Start();
        }

        public void Dispose()
        {
            stopWatch.Stop();
            Report.info(title + " finish, used time=" + stopWatch.ElapsedMilliseconds + "ms");
        }

        #endregion 主要函式
    }
}