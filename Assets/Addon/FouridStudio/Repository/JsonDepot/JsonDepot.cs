using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FouridStudio
{
    /// <summary>
    /// json列表資料庫
    /// </summary>
    /// <typeparam name="T">資料型態</typeparam>
    public class JsonDepot<T> : IEnumerable where T : class
    {
        #region 定義

        /// <summary>
        /// 索引解析委派
        /// </summary>
        /// <param name="obj">資料物件</param>
        /// <returns>索引物件</returns>
        public delegate object ParseKey(T obj);

        #endregion 定義

        #region 屬性

        /// <summary>
        /// 資料列表
        /// </summary>
        private Dictionary<object, T> datas = new Dictionary<object, T>();

        #endregion 屬性

        #region 主要函式

        public IEnumerator GetEnumerator()
        {
            return datas.GetEnumerator();
        }

        /// <summary>
        /// 開啟資料庫
        /// </summary>
        /// <param name="jsons">文字檔案內容列表</param>
        /// <param name="parseKey">索引解析委派</param>
        /// <returns>資料庫物件</returns>
        public JsonDepot<T> open(IEnumerable<string> jsons, ParseKey parseKey)
        {
            close();

            if (parseKey == null)
                throw new Exception("parse key null");

            foreach (string itor in jsons)
            {
                T data = JsonMapper.ToObject<T>(itor);

                if (data == null)
                    throw new Exception("parse data failed");

                object key = parseKey(data);

                if (key == null)
                    throw new Exception("parse key failed");

                datas.Add(key, data);
            }//for

            return this;
        }

        /// <summary>
        /// 關閉資料庫
        /// </summary>
        public void close()
        {
            datas.Clear();
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <param name="key">索引物件</param>
        /// <returns>資料物件</returns>
        public T get(object key)
        {
            return datas.ContainsKey(key) ? datas[key] : null;
        }

        /// <summary>
        /// 取得全部資料
        /// </summary>
        /// <returns>資料物件列表</returns>
        public IEnumerable<T> getAll()
        {
            return datas.Values.ToList();
        }

        #endregion 主要函式
    }
}