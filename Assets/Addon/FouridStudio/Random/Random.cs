namespace FouridStudio
{
    /// <summary>
    /// 預設隨機類別
    /// </summary>
    public class Random : RandomInterface
    {
        #region 屬性

        /// <summary>
        /// 使用系統提供的隨機物件
        /// </summary>
        private System.Random random = null;

        /// <summary>
        /// 隨機種子
        /// </summary>
        private string seed = "default seed";

        #endregion 屬性

        #region 主要函式

        public Random()
        {
            this.random = new System.Random();
        }

        public Random(int seed)
        {
            this.random = new System.Random(seed);
            this.seed = seed.ToString();
        }

        public string getSeed()
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