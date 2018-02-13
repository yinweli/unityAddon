namespace FouridStudio
{
    /// <summary>
    /// 隨機取值介面
    /// </summary>
    public interface RandomInterface
    {
        string getSeed();

        int randomValue();

        int randomValue(int max);

        int randomValue(int min, int max);
    }
}