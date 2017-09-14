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
        private Dictionary<string, Event> couriers = new Dictionary<string, Event>();

        public Event this[string subject]
        {
            get
            {
                if (couriers.ContainsKey(subject) == false)
                    couriers[subject] = new Event();

                return couriers[subject];
            }
        }

        #endregion 屬性
    }
}