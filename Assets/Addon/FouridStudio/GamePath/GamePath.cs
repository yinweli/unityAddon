using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 遊戲路徑
    /// </summary>
    public class GamePath
    {
        #region 定義

        /// <summary>
        /// 設置資料夾
        /// </summary>
        private const string PathConfig = "config";

        /// <summary>
        /// mod資料夾
        /// </summary>
        private const string PathMod = "mod";

        /// <summary>
        /// 存檔資料夾
        /// </summary>
        private const string PathSave = "save";

        /// <summary>
        /// 紀錄資料夾
        /// </summary>
        private const string PathLog = "log";

        #endregion 定義

        #region 屬性

        /// <summary>
        /// 我的文件夾路徑
        /// </summary>
        private static string myDocuments = "";

        /// <summary>
        /// 設置文件夾路徑
        /// </summary>
        private static string config = "";

        /// <summary>
        /// mod文件夾路徑
        /// </summary>
        private static string mod = "";

        /// <summary>
        /// 存檔文件夾路徑
        /// </summary>
        private static string save = "";

        /// <summary>
        /// 紀錄文件夾路徑
        /// </summary>
        private static string log = "";

        #endregion 屬性

        #region 主要函式

        /// <summary>
        /// 取得我的文件夾路徑
        /// </summary>
        public static string MyDocuments
        {
            get
            {
                if (myDocuments.Length <= 0)
                    myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                return myDocuments;
            }
        }

        /// <summary>
        /// 取得設置文件夾路徑
        /// </summary>
        public static string Config
        {
            get
            {
                if (config.Length <= 0)
                    config = pathsCombine(MyDocuments, Application.companyName, Application.productName, PathConfig);

                return config;
            }
        }

        /// <summary>
        /// 取得mod文件夾路徑
        /// </summary>
        public static string Mod
        {
            get
            {
                if (mod.Length <= 0)
                    mod = pathsCombine(MyDocuments, Application.companyName, Application.productName, PathMod);

                return mod;
            }
        }

        /// <summary>
        /// 取得存檔文件夾路徑
        /// </summary>
        public static string Save
        {
            get
            {
                if (save.Length <= 0)
                    save = pathsCombine(MyDocuments, Application.companyName, Application.productName, PathSave);

                return save;
            }
        }

        /// <summary>
        /// 取得紀錄文件夾路徑
        /// </summary>
        public static string Log
        {
            get
            {
                if (log.Length <= 0)
                    log = pathsCombine(MyDocuments, Application.companyName, Application.productName, PathLog);

                return log;
            }
        }

        #endregion 主要函式

        #region 內部函式

        /// <summary>
        /// 合併路徑列表為路徑字串
        /// </summary>
        /// <param name="paths">路徑列表</param>
        /// <returns>路徑字串</returns>
        private static string pathsCombine(params string[] paths)
        {
            return paths.Aggregate((current, next) => Path.Combine(current, next));
        }

        #endregion 內部函式
    }
}