namespace FouridStudio
{
    /// <summary>
    /// 系統隨機類別
    /// </summary>
    public class SystemRandom : RandomInterface
    {
        #region 屬性

        /// <summary>
        /// 使用系統提供的隨機物件
        /// </summary>
        private System.Random random = null;

        /// <summary>
        /// 隨機種子
        /// </summary>
        private int seed = 0;

        #endregion 屬性

        #region 主要函式

        public SystemRandom()
        {
            this.random = new System.Random();
        }

        public SystemRandom(int seed)
        {
            this.random = new System.Random(this.seed = seed);
        }

        public int getSeed()
        {
            return seed;
        }

        /// <summary>
        /// 取得隨機值
        /// </summary>
        /// <returns>隨機值</returns>
        public int randomValue()
        {
            return random.Next();
        }

        /// <summary>
        /// 取得隨機值
        /// </summary>
        /// <param name="max">最大值</param>
        /// <returns>隨機值</returns>
        public int randomValue(int max)
        {
            return random.Next(max);
        }

        /// <summary>
        /// 取得隨機值
        /// </summary>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        /// <returns>隨機值</returns>
        public int randomValue(int min, int max)
        {
            return random.Next(min, max);
        }

        #endregion 主要函式
    }
}