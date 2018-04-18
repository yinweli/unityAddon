using System;
using System.IO;
using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 回報執行紀錄
    /// </summary>
    public class Report
    {
        #region 主要函式

        /// <summary>
        /// 回報訊息
        /// </summary>
        /// <param name="message">訊息字串</param>
        public static void info(string message)
        {
            outputLog("[Info] " + message);
        }

        /// <summary>
        /// 回報錯誤
        /// </summary>
        /// <param name="message">訊息字串</param>
        public static void error(string message)
        {
            outputLog("[Error] " + message);
        }

        /// <summary>
        /// 回報錯誤
        /// </summary>
        /// <param name="message">訊息字串</param>
        /// <param name="exception">錯誤物件</param>
        public static void error(string message, Exception exception)
        {
            outputLog("[Error] " + message);
            outputLog("[Exception] " + exception);
        }

        /// <summary>
        /// 回報錯誤
        /// </summary>
        /// <param name="exception">錯誤物件</param>
        public static void error(Exception exception)
        {
            outputLog("[Exception] " + exception);
        }

        #endregion 主要函式

        #region 內部函式

        private static void outputLog(string message)
        {
            outputDebugLog(message);
            outputReleaseLog(message);
        }

        private static void outputDebugLog(string message)
        {
            if (Debug.isDebugBuild)
                Debug.Log(message);
        }

        private static void outputReleaseLog(string message)
        {
            Directory.CreateDirectory(GamePath.Log);

            string logFileName = DateTime.Now.ToString("yyyy-MM-dd") + " " + Application.productName + ".log";
            string logFilePath = Path.Combine(GamePath.Log, logFileName);
            string logMessageWithTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + message + Environment.NewLine;

            File.AppendAllText(logFilePath, logMessageWithTime);
        }

        #endregion 內部函式
    }
}