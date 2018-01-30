using System.Collections.Generic;
using UnityEngine.Events;

namespace FouridStudio
{
    /// <summary>
    /// 訊息接收發佈
    /// 用來處理不同系統間的訊息傳遞
    /// </summary>
    public class Courier<T>
    {
        #region 定義

        /// <summary>
        /// 訊息接收者類別
        /// </summary>
        public class Receiver : UnityEvent<System.Object>
        {
        }

        #endregion 定義

        #region 屬性

        /// <summary>
        /// 執行未註冊訊息通知委派
        /// </summary>
        public UnityAction<T> onInvokEmpty = null;

        /// <summary>
        /// 訊息接收者列表
        /// </summary>
        private Dictionary<T, Receiver> receivers = new Dictionary<T, Receiver>();

        #endregion 屬性

        #region 主要函式

        /// <summary>
        /// 新增訊息接收委派
        /// </summary>
        /// <param name="subject">標題</param>
        /// <param name="call">訊息接收委派</param>
        public void add(T subject, UnityAction<System.Object> call)
        {
            getReceiver(subject).AddListener(call);
        }

        /// <summary>
        /// 移除訊息接收委派
        /// </summary>
        /// <param name="subject">標題</param>
        /// <param name="call">訊息接收委派</param>
        public void remove(T subject, UnityAction<System.Object> call)
        {
            getReceiver(subject).RemoveListener(call);
        }

        /// <summary>
        /// 執行訊息
        /// </summary>
        /// <param name="subject">標題</param>
        public void invok(T subject)
        {
            invok(subject, null);
        }

        /// <summary>
        /// 執行訊息
        /// </summary>
        /// <param name="subject">標題</param>
        /// <param name="argument">參數</param>
        public void invok(T subject, System.Object argument)
        {
            Receiver receiver = getReceiver(subject);

            if (receiver.GetPersistentEventCount() > 0)
                receiver.Invoke(argument);
            else
            {
                if (onInvokEmpty != null)
                    onInvokEmpty(subject);
            }//if
        }

        #endregion 主要函式

        #region 內部函式

        /// <summary>
        /// 取得訊息接收者
        /// </summary>
        /// <param name="subject">標題</param>
        /// <returns>訊息接收者</returns>
        private Receiver getReceiver(T subject)
        {
            if (receivers.ContainsKey(subject) == false)
                receivers[subject] = new Receiver();

            return receivers[subject];
        }

        #endregion 內部函式
    }
}