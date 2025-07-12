using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace SwaggerDemoApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("🔥 CustomAuthFilter triggered");

            var headers = context.HttpContext.Request.Headers;

            // 1. Header not present
            if (!headers.ContainsKey("Authorization"))
            {
                context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
                return;
            }

            var token = headers["Authorization"].ToString();

            // 2. Header present but does not contain 'Bearer'
            if (!token.Contains("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
                return;
            }

            // ✅ Token contains Bearer → continue
            base.OnActionExecuting(context);
        }
    }
}
