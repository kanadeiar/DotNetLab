using System.Text.Json;

namespace AspNetCore.Infra;

public static class Extensions
{
    public static string PathAndQuery(this HttpRequest request)
    {
        return request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
    }
    public static void SetJson(this ISession session, string key, object value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }
    public static T? GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);
        return sessionData == null
            ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
    }
}