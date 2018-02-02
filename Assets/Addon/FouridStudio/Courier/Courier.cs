using System.Collections.Generic;
using UnityEngine.Events;

namespace FouridStudio
{
    /// <summary>
    /// 訊息接收發佈
    /// 用來處理不同系統間的訊息傳遞
    /// </summary>
    public class Courier : Singleton<Courier>
    {
        #region 定義

        /// <summary>
        /// 訊息接收者類別
        /// </summary>
        private class Receiver : UnityEvent<System.Object>
        {
        }

        #endregion 定義

        #region 屬性

        /// <summary>
        /// 執行訊息委派通知
        /// </summary>
        public UnityAction<int> onInvok = null;

        /// <summary>
        /// 訊息接收者列表
        /// </summary>
        private Dictionary<int, Receiver> receivers = new Dictionary<int, Receiver>();

        #endregion 屬性

        #region 主要函式

        /// <summary>
        /// 新增訊息委派
        /// </summary>
        /// <param name="index">索引值</param>
        /// <param name="call">訊息接收委派</param>
        public void add(int index, UnityAction<System.Object> call)
        {
            getReceiver(index).AddListener(call);
        }

        /// <summary>
        /// 移除訊息委派
        /// </summary>
        /// <param name="index">索引值</param>
        /// <param name="call">訊息接收委派</param>
        public void remove(int index, UnityAction<System.Object> call)
        {
            getReceiver(index).RemoveListener(call);
        }

        /// <summary>
        /// 執行訊息委派
        /// </summary>
        /// <param name="index">索引值</param>
        public void invok(int index)
        {
            invok(index, null);

            if (onInvok != null)
                onInvok(index);
        }

        /// <summary>
        /// 執行訊息委派
        /// </summary>
        /// <param name="index">索引值</param>
        /// <param name="argument">參數</param>
        public void invok(int index, System.Object argument)
        {
            getReceiver(index).Invoke(argument);
        }

        #endregion 主要函式

        #region 內部函式

        /// <summary>
        /// 取得訊息接收者
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>訊息接收者</returns>
        private Receiver getReceiver(int index)
        {
            if (receivers.ContainsKey(index) == false)
                receivers[index] = new Receiver();

            return receivers[index];
        }

        #endregion 內部函式
    }
}