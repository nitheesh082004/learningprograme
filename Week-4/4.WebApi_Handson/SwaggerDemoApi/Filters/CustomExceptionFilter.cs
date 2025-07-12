using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace SwaggerDemoApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var message = $"[{DateTime.Now}] Exception: {exception.Message}\nStackTrace: {exception.StackTrace}\n\n";

            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "logs");
            Directory.CreateDirectory(logPath);

            var filePath = Path.Combine(logPath, "exceptions.log");
            File.AppendAllText(filePath, message);

            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}
