﻿using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 繼承此類別後, 便擁有Singleton設計模式的能力
    /// 這是給Unity物件的特化版
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonMono<T> : MonoBehaviour where T : Object, new()
    {
        #region 屬性

        private static T instance = null;

        public static T Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType<T>();

                return instance;
            }
        }

        #endregion 屬性

        #region Unity事件

        private void Awake()
        {
            if (instance == null)
                instance = this as T;
            else
                DestroyImmediate(this.gameObject);
        }

        private void OnDestroy()
        {
            if (instance == this)
                instance = null;
        }

        #endregion Unity事件
    }
}