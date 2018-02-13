using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 遊戲路徑
    /// </summary>
    public class GamePath : Singleton<GamePath>
    {
        #region 定義

        /// <summary>
        /// 設置資料夾
        /// </summary>
        private const string Config = "config";

        /// <summary>
        /// mod資料夾
        /// </summary>
        private const string Mod = "mod";

        /// <summary>
        /// 存檔資料夾
        /// </summary>
        private const string Save = "save";

        /// <summary>
        /// 紀錄資料夾
        /// </summary>
        private const string Log = "log";

        #endregion 定義

        #region 屬性

        /// <summary>
        /// 我的文件夾路徑
        /// </summary>
        private string pathMyDocuments = "";

        /// <summary>
        /// 設置文件夾路徑
        /// </summary>
        private string pathConfig = "";

        /// <summary>
        /// mod文件夾路徑
        /// </summary>
        private string pathMod = "";

        /// <summary>
        /// 存檔文件夾路徑
        /// </summary>
        private string pathSave = "";

        /// <summary>
        /// 紀錄文件夾路徑
        /// </summary>
        private string pathLog = "";

        #endregion 屬性

        #region 主要函式

        /// <summary>
        /// 取得StreamAssets路徑
        /// </summary>
        public string PathStreamAssets
        {
            get
            {
#if UNITY_EDITOR
                return Application.streamingAssetsPath;
#elif UNITY_ANDROID
                return Application.persistentDataPath;
#elif UNITY_IOS
                return Application.persistentDataPath;
#else
                return Application.streamingAssetsPath;
#endif
            }
        }

        /// <summary>
        /// 取得我的文件夾路徑
        /// </summary>
        public string PathMyDocuments
        {
            get
            {
                if (pathMyDocuments.Length <= 0)
                    pathMyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                return pathMyDocuments;
            }
        }

        /// <summary>
        /// 取得設置文件夾路徑
        /// </summary>
        public string PathConfig
        {
            get
            {
                if (pathConfig.Length <= 0)
                    pathConfig = pathCombine(PathMyDocuments, Application.companyName, Application.productName, Config);

                return pathConfig;
            }
        }

        /// <summary>
        /// 取得mod文件夾路徑
        /// </summary>
        public string PathMod
        {
            get
            {
                if (pathMod.Length <= 0)
                    pathMod = pathCombine(PathMyDocuments, Application.companyName, Application.productName, Mod);

                return pathMod;
            }
        }

        /// <summary>
        /// 取得存檔文件夾路徑
        /// </summary>
        public string PathSave
        {
            get
            {
                if (pathSave.Length <= 0)
                    pathSave = pathCombine(PathMyDocuments, Application.companyName, Application.productName, Save);

                return pathSave;
            }
        }

        /// <summary>
        /// 取得紀錄文件夾路徑
        /// </summary>
        public string PathLog
        {
            get
            {
                if (pathLog.Length <= 0)
                    pathLog = pathCombine(PathMyDocuments, Application.companyName, Application.productName, Log);

                return pathLog;
            }
        }

        /// <summary>
        /// 合併路徑列表為路徑字串
        /// </summary>
        /// <param name="paths">路徑列表</param>
        /// <returns>路徑字串</returns>
        public string pathCombine(params string[] paths)
        {
            return paths.Aggregate((current, next) => Path.Combine(current, next));
        }

        #endregion 主要函式
    }
}