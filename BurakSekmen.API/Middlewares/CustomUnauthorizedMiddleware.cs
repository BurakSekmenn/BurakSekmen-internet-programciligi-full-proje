using Microsoft.AspNetCore.Authorization;

namespace BurakSekmen.API.Middlewares
{
    public class CustomUnauthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomUnauthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint != null && endpoint.Metadata.GetMetadata<IAllowAnonymous>() == null && !context.User.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"message\": \"Unauthorized: Token is missing or invalid.\"}");
                return;
            }

            await _next(context);
        }
    }
    public static class CustomUnauthorizedMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomUnauthorizedMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomUnauthorizedMiddleware>();
        }
    }
}
