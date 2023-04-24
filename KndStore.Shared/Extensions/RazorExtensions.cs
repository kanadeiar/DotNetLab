using Microsoft.AspNetCore.Http;

namespace KndStore.Shared.Extensions;

public static class RazorExtensions
{
    public static string PathAndQuery(this HttpRequest request)
    {
        return request.QueryString.HasValue
            ? $"{request.Path}{request.QueryString}"
            : request.Path.ToString();
    }
}

