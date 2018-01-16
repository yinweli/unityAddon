using FouridStudio;
using LitJson;

/// <summary>
/// LitJson配接器
/// </summary>
public class LitJsonAdaper<T> : JsonAdaper<T>
{
    public string toJson(T obj)
    {
        return JsonMapper.ToJson(obj);
    }

    public T toObject(string json)
    {
        return JsonMapper.ToObject<T>(json);
    }
}