using System.Collections.Generic;

namespace FouridStudio
{
    /// <summary>
    /// 參數儲存庫
    /// 使用者可以加入參數
    /// 取出參數時參數就會被刪除
    /// </summary>
    public class Vault : Singleton<Vault>
    {
        #region 屬性

        /// <summary>
        /// 參數列表
        /// </summary>
        private Dictionary<int, object> vaults = new Dictionary<int, object>();

        #endregion 屬性

        #region 主要函式

        /// <summary>
        /// 新增參數
        /// </summary>
        /// <typeparam name="T">參數型別</typeparam>
        /// <param name="index">索引值</param>
        /// <param name="value">參數</param>
        public void add<T>(int index, T value)
        {
            vaults[index] = value;
        }

        /// <summary>
        /// 取得參數
        /// 取得參數後, 儲存庫會刪除此紀錄
        /// </summary>
        /// <typeparam name="T">參數型別</typeparam>
        /// <param name="index">索引值</param>
        /// <returns>參數</returns>
        public T get<T>(int index)
        {
            if (vaults.ContainsKey(index) == false)
                return default(T);

            object value = vaults[index];

            vaults.Remove(index);

            return (T)value;
        }

        /// <summary>
        /// 取得參數
        /// 取得參數後, 儲存庫不會刪除此紀錄
        /// </summary>
        /// <typeparam name="T">參數型別</typeparam>
        /// <param name="index">索引值</param>
        /// <returns>參數</returns>
        public T peek<T>(int index)
        {
            if (vaults.ContainsKey(index) == false)
                return default(T);

            return (T)vaults[index];
        }

        #endregion 主要函式
    }
}