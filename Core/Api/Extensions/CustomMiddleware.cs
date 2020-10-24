using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Extensions
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Request.Headers.TryGetValue("thecodebuzz", out var traceValue);

            if (string.IsNullOrWhiteSpace(traceValue))
            {
                traceValue = new Guid().ToString();
                httpContext.Response.OnStarting((state) =>
                {
                    httpContext.Response.Headers.Add("x-the-code-buzz", traceValue);
                    return Task.FromResult(0);
                }, httpContext);
            }

            await _next(httpContext);
        }
    }
}
