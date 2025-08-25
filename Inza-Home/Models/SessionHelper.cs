public static class SessionHelper
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static void Configure(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public static string? GetSessionValue(string key)
    {
        return _httpContextAccessor?.HttpContext?.Session.GetString(key);
    }

    public static void SetSessionValue(string key, string value)
    {
        _httpContextAccessor?.HttpContext?.Session.SetString(key, value);
    }
}