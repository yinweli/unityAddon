using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 資料路徑
    /// </summary>
    public class Route
    {
        #region 屬性

        /// <summary>
        /// StreamAssets路徑
        /// </summary>
        public static string STREAM_ASSETS_PATH
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

        #endregion 屬性
    }
}