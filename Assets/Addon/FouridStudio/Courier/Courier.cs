using System.Collections.Generic;
using UnityEngine.Events;

namespace FouridStudio
{
    /// <summary>
    /// 訊息接收發佈
    /// 用來處理不同系統間的訊息傳遞
    /// </summary>
    public class Courier<T> : Singleton<Courier<T>>
    {
        #region 定義

        /// <summary>
        /// 訊息事件類別
        /// </summary>
        public class Event : UnityEvent<System.Object>
        {
        }

        #endregion 定義

        #region 屬性

        /// <summary>
        /// 訊息事件列表
        /// </summary>
        private Dictionary<T, Event> couriers = new Dictionary<T, Event>();

        public Event this[T value]
        {
            get
            {
                if (couriers.ContainsKey(value) == false)
                    couriers[value] = new Event();

                return couriers[value];
            }
        }

        #endregion 屬性
    }
}