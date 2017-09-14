using System;
using System.Collections.Generic;
using System.Linq;

namespace FouridStudio
{
    /// <summary>
    /// 多面骰
    /// </summary>
    public class Dice<T>
    {
        #region 屬性

        /// <summary>
        /// 隨機物件
        /// </summary>
        private Random random = null;

        /// <summary>
        /// 骰子內容列表
        /// </summary>
        private SortedDictionary<int, T> dices = new SortedDictionary<int, T>();

        /// <summary>
        /// 骰子最大值
        /// </summary>
        private int max = 0;

        public int Max
        {
            get
            {
                return max;
            }
        }

        public int Count
        {
            get
            {
                return dices.Count;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return dices.Count <= 0;
            }
        }

        #endregion 屬性

        #region 主要函式

        public Dice()
        {
            random = new Random();
        }

        public Dice(Random random)
        {
            this.random = random;
        }

        /// <summary>
        /// 新增項目
        /// </summary>
        /// <param name="probability">機率值</param>
        /// <param name="data">資料物件</param>
        public void add(int probability, T data)
        {
            dices[max += probability] = data;
        }

        /// <summary>
        /// 取得隨機項目
        /// </summary>
        /// <returns>資料物件</returns>
        public T roll()
        {
            return roll(random.Next(0, max));
        }

        /// <summary>
        /// 取得指定值代表的項目
        /// </summary>
        /// <param name="value">值</param>
        /// <returns>資料物件</returns>
        public T roll(int value)
        {
            return dices.Where(itor => itor.Key >= value).Select(itor => itor.Value).FirstOrDefault();
        }

        #endregion 主要函式
    }
}