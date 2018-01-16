using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FouridStudio
{
    /// <summary>
    /// json資料庫的資料基底介面
    /// </summary>
    public interface RepositoryJsonBase
    {
        /// <summary>
        /// 取得索引
        /// </summary>
        /// <returns>索引</returns>
        object getKey();
    }

    /// <summary>
    /// json資料庫
    /// </summary>
    /// <typeparam name="T">資料型態</typeparam>
    public class RepositoryJson<T> : IEnumerable where T : class, RepositoryJsonBase
    {
        #region 屬性

        /// <summary>
        /// json配接器
        /// </summary>
        private JsonAdaper<T> jsonAdaper = null;

        /// <summary>
        /// 資料列表
        /// </summary>
        private Dictionary<object, T> datas = new Dictionary<object, T>();

        #endregion 屬性

        #region 主要函式

        public RepositoryJson(JsonAdaper<T> jsonAdaper)
        {
            this.jsonAdaper = jsonAdaper;
        }

        public IEnumerator GetEnumerator()
        {
            return datas.GetEnumerator();
        }

        /// <summary>
        /// 開啟資料庫
        /// </summary>
        /// <param name="jsons">文字檔案內容列表</param>
        /// <returns>資料庫物件</returns>
        public RepositoryJson<T> open(IEnumerable<string> jsons)
        {
            close();

            if (jsonAdaper == null)
                throw new Exception("json adaper null");

            foreach (string itor in jsons)
            {
                T data = jsonAdaper.toObject(itor) as T;

                if (data == null)
                    throw new Exception("parse data failed");

                object key = data.getKey();

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