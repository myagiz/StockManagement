using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using Core.Utilities.Results.Concrete.ErrorResults;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        private FileLogger _logger;


        public ExceptionMiddleware(RequestDelegate next, FileLogger logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                _logger.Error(e);
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            string message = "Internal Server Error";

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new ErrorDataResult<ErrorDetails>(null, message)));
        }
    }
}
