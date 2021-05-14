using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TestTaskProm.Web.Infrastructure
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex)
            {
                Log.Error($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext);
            }
        }
        private Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync("Internal Server Error.");
        }
    }
}
