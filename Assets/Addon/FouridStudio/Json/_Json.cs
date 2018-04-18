namespace FouridStudio
{
    /// <summary>
    /// json介面
    /// </summary>
    /// <typeparam name="T">資料型態</typeparam>
    public interface JsonInterface<T>
    {
        /// <summary>
        /// 從物件轉為json字串
        /// </summary>
        /// <param name="obj">物件</param>
        /// <returns>json字串</returns>
        string toJson(T obj);

        /// <summary>
        /// 從json字串轉為物件
        /// </summary>
        /// <param name="json">json字串</param>
        /// <returns>物件</returns>
        T toObject(string json);
    }
}