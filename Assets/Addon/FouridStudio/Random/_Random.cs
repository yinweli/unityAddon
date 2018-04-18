namespace FouridStudio
{
    /// <summary>
    /// 隨機介面
    /// </summary>
    public interface RandomInterface
    {
        int getSeed();

        int randomValue();

        int randomValue(int max);

        int randomValue(int min, int max);
    }
}