using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace DemoMiddleware.Middlewares
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;

        public FirstMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Items.Add("FirstMiddleware", $"<p>URL: {context.Request.Path}</p>");
            await _next(context);
        }
    }
}
