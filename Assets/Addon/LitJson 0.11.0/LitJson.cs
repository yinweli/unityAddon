using FouridStudio;
using LitJson;

/// <summary>
/// LitJson
/// </summary>
public class LitJson<T> : JsonInterface<T>
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