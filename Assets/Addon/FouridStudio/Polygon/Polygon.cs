using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 多邊形工具
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// 檢查座標是否位於多邊形內
        /// </summary>
        /// <param name="polygon">多邊形頂點座標列表</param>
        /// <param name="point">座標</param>
        /// <returns>true表示位於多邊形內, false則否</returns>
        public static bool inside(Vector2[] polygon, Vector2 point)
        {
            bool result = false;

            for (int i = 0, j = polygon.Length - 1; i < polygon.Length; j = i++)
            {
                if (((polygon[i].y <= point.y && point.y < polygon[j].y) || (polygon[j].y <= point.y && point.y < polygon[i].y)) &&
                    (point.x < (polygon[j].x - polygon[i].x) * (point.y - polygon[i].y) / (polygon[j].y - polygon[i].y) + polygon[i].x))
                    result = !result;
            }//for

            return result;
        }
    }
}