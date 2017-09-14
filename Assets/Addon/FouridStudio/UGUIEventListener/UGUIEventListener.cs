using UnityEngine;
using UnityEngine.EventSystems;

namespace FouridStudio
{
    /// <summary>
    /// UGUI事件
    /// </summary>
    public class UGUIEventListener : EventTrigger
    {
        #region 定義

        /// <summary>
        /// UGUI事件委派
        /// </summary>
        /// <param name="gameObject">參數</param>
        public delegate void UGUIEvent(GameObject gameObject);

        #endregion 定義

        #region 屬性

        public UGUIEvent onClick;
        public UGUIEvent onDown;
        public UGUIEvent onUp;
        public UGUIEvent onEnter;
        public UGUIEvent onExit;

        #endregion 屬性

        #region 主要函式

        /// <summary>
        /// 取得物件的UGUI事件組件
        /// 如果該物件沒有此組件, 則會增添此組件
        /// </summary>
        /// <param name="gameObject">物件</param>
        /// <returns>UGUI事件組件</returns>
        public static UGUIEventListener Get(GameObject gameObject)
        {
            UGUIEventListener listener = gameObject.GetComponent<UGUIEventListener>();

            if (listener == null)
                listener = gameObject.AddComponent<UGUIEventListener>();

            return listener;
        }

        #endregion 主要函式

        #region UI事件

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (onClick != null)
                onClick(gameObject);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (onDown != null)
                onDown(gameObject);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (onUp != null)
                onUp(gameObject);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (onEnter != null)
                onEnter(gameObject);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (onExit != null)
                onExit(gameObject);
        }

        #endregion UI事件
    }
}