namespace BigEshop.Web.Extensions
{
    public static class HttpContextExtension
    {
        public static string GetUserIp(this HttpContext httpContext)
        => httpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
    }
}
