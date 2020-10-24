using ApplicationServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Model.ErrorModel;
using System;
using System.Net;

namespace Api.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {

                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature?.Error is BussinessException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var result = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature?.Error.Message
                        }.ToString();

                        await context.Response.WriteAsync(result).ConfigureAwait(false);
                    }
                    else if (contextFeature?.Error is TimeoutException)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.RequestTimeout;
                        var result = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature?.Error.Message
                        }.ToString();

                        await context.Response.WriteAsync(result).ConfigureAwait(false);
                    }
                    else if (contextFeature != null)
                    {


                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var result = new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString();

                        await context.Response.WriteAsync(result).ConfigureAwait(false);
                    }
                });
            });
        }
    }
}
