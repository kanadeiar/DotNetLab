using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace KndStore.Shared.Extensions;

public static class JsonExtensions
{
    public static void SetJson<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize<T>(value));
    }
    public static T? GetJson<T>(this ISession session, string key)
    {
        var sessionData = session.GetString(key);
        return sessionData is { } ? JsonSerializer.Deserialize<T>(sessionData) : default;
    }
}

