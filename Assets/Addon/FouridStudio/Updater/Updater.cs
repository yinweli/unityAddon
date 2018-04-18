using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

namespace FouridStudio
{
    /// <summary>
    /// 定期更新處理
    /// 用來統一管理不同系統的定期更新
    /// 有文章表明, 多個物件執行Update函式的效能不及單一Update函式執行
    /// 所以使用此管理器來執行Update
    /// 使用時請把此腳本掛到任一物件上即可
    /// </summary>
    public class Updater : SingletonMono<Updater>
    {
        #region 定義

        /// <summary>
        /// 執行委派
        /// </summary>
        public delegate void Execute();

        #endregion 定義

        #region 屬性

#pragma warning disable 0414

        /// <summary>
        /// 定時更新的數量
        /// </summary>
        [SerializeField, ReadOnly]
        private int countOfUpdate = 0;

        /// <summary>
        /// 上次更新處理執行時間
        /// </summary>
        [SerializeField, ReadOnly]
        private long milliseconds = 0;

#pragma warning restore 0414

        /// <summary>
        /// 全域暫停旗標
        /// </summary>
        [SerializeField, ReadOnly]
        private bool pause = false;

        /// <summary>
        /// 計時器
        /// </summary>
        private Stopwatch stopwatch = new Stopwatch();

        /// <summary>
        /// 更新列表
        /// </summary>
        private Dictionary<int, Element> updates = new Dictionary<int, Element>();

        #endregion 屬性

        #region Unity事件

        private void Update()
        {
            if (pause)
                return;

            stopwatch.Reset();
            stopwatch.Start();

            updates.Values.ToList().ForEach(itor => itor.update());
            milliseconds = stopwatch.ElapsedMilliseconds;

            stopwatch.Stop();
        }

        #endregion Unity事件

        #region 主要函式

        /// <summary>
        /// 新增更新
        /// </summary>
        /// <param name="execute">執行委派</param>
        /// <param name="interval">間隔時間(毫秒)</param>
        /// <returns>索引值</returns>
        public int add(Execute execute, int interval)
        {
            Element element = new Element(execute, interval);

            updates.Add(element.getIndex(), element);
            countOfUpdate = updates.Count;

            return element.getIndex();
        }

        /// <summary>
        /// 新增更新
        /// </summary>
        /// <param name="execute">執行委派</param>
        /// <param name="interval">間隔時間(秒)</param>
        /// <returns>索引值</returns>
        public int add(Execute execute, float interval)
        {
            Element element = new Element(execute, (int)(interval * 1000));

            updates.Add(element.getIndex(), element);
            countOfUpdate = updates.Count;

            return element.getIndex();
        }

        /// <summary>
        /// 移除更新
        /// </summary>
        /// <param name="index">索引值</param>
        public void remove(int index)
        {
            updates.Remove(index);
            countOfUpdate = updates.Count;
        }

        /// <summary>
        /// 取得單項暫停旗標
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>暫停旗標</returns>
        public bool getPause(int index)
        {
            Element element = updates.ContainsKey(index) ? updates[index] : null;

            return element != null ? element.getPause() : false;
        }

        /// <summary>
        /// 設定單項啟動/暫停定時更新
        /// </summary>
        /// <param name="index">索引值</param>
        /// <param name="pause">暫停旗標</param>
        public void setPause(int index, bool pause)
        {
            Element element = updates.ContainsKey(index) ? updates[index] : null;

            if (element != null)
                element.setPause(pause);
        }

        /// <summary>
        /// 取得全域暫停旗標
        /// </summary>
        /// <returns>暫停旗標</returns>
        public bool getAllPause()
        {
            return pause;
        }

        /// <summary>
        /// 設定全域啟動/暫停定時更新
        /// </summary>
        /// <param name="pause">暫停旗標</param>
        public void setAllPause(bool pause)
        {
            this.pause = pause;
        }

        #endregion 主要函式

        #region 子類別

        /// <summary>
        /// 索引編製
        /// </summary>
        private class Indexer
        {
            /// <summary>
            /// 索引值
            /// </summary>
            private static int index = 0;

            public static int Index
            {
                get
                {
                    return ++index;
                }
            }
        }

        /// <summary>
        /// 更新元素
        /// </summary>
        private class Element
        {
            /// <summary>
            /// 索引值
            /// </summary>
            private int index = Indexer.Index;

            /// <summary>
            /// 計時器
            /// </summary>
            private Stopwatch stopwatch = new Stopwatch();

            /// <summary>
            /// 執行委派
            /// </summary>
            private Execute execute = null;

            /// <summary>
            /// 間隔時間(毫秒)
            /// </summary>
            private int interval = 0;

            /// <summary>
            /// 暫停旗標
            /// </summary>
            private bool pause = false;

            public Element(Execute execute, int interval)
            {
                this.stopwatch.Reset();
                this.stopwatch.Start();
                this.execute = execute;
                this.interval = interval;
            }

            public void update()
            {
                if (stopwatch.ElapsedMilliseconds < interval)
                    return;

                if (execute != null && pause == false)
                    execute();

                stopwatch.Reset();
                stopwatch.Start();
            }

            public int getIndex()
            {
                return index;
            }

            public bool getPause()
            {
                return pause;
            }

            public void setPause(bool pause)
            {
                this.pause = pause;
            }
        }

        #endregion 子類別
    }
}