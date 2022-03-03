using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DemoMiddleware.Middlewares
{
    public class SecondMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            if (context.Request.Path == "/xxx.html")
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban khong duoc truy cap");
                var firtMiddlewareData = context.Items["FirstMiddleware"];
                context.Response.Headers.Add("dataFirstMiddleware", (string)firtMiddlewareData);

            }

            else
            {
                context.Response.Headers.Add("SecondMiddleware", "Ban duoc truy cap");
                await next(context);
            }
        }
    }
}
