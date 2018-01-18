using System;
using System.IO;
using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 回報執行紀錄
    /// </summary>
    public class Report : Singleton<Report>
    {
        #region 主要函式

        /// <summary>
        /// 回報訊息
        /// </summary>
        /// <param name="message">訊息字串</param>
        public void info(string message)
        {
            outputLog("[Info] " + message);
        }

        /// <summary>
        /// 回報錯誤
        /// </summary>
        /// <param name="message">訊息字串</param>
        public void error(string message)
        {
            outputLog("[Error] " + message);
        }

        /// <summary>
        /// 回報錯誤
        /// </summary>
        /// <param name="message">訊息字串</param>
        /// <param name="exception">錯誤物件</param>
        public void error(string message, Exception exception)
        {
            outputLog("[Error] " + message);
            outputLog("[Exception] " + exception);
        }

        /// <summary>
        /// 回報錯誤
        /// </summary>
        /// <param name="exception">錯誤物件</param>
        public void error(Exception exception)
        {
            outputLog("[Exception] " + exception);
        }

        #endregion 主要函式

        #region 內部函式

        private void outputLog(string message)
        {
            outputDebugLog(message);
            outputReleaseLog(message);
        }

        private void outputDebugLog(string message)
        {
            if (Debug.isDebugBuild)
                Debug.Log(message);
        }

        private void outputReleaseLog(string message)
        {
            Directory.CreateDirectory(GamePath.Instance.PathLog);

            string logFileName = getCurrentDateString() + " " + Application.productName + ".log";
            string logFilePath = Path.Combine(GamePath.Instance.PathLog, logFileName);
            string logMessageWithTime = getCurrentTimeString() + " " + message + Environment.NewLine;

            File.AppendAllText(logFilePath, logMessageWithTime);
        }

        private string getCurrentDateString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        private string getCurrentTimeString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        #endregion 內部函式
    }
}