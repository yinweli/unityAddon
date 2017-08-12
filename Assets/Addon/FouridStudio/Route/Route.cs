using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// ��Ƹ��|���O
    /// </summary>
    public class Route
    {
        /// <summary>
        /// StreamAssets���|
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
    }
}