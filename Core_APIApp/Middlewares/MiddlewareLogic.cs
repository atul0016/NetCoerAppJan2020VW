using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_APIApp.Middlewares
{
    /// <summary>
    /// DTO class for Error Message
    /// </summary>
    public class ErrorInformation
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// This class will have the logic for Error Handling
    /// The class will be ctor injectected with requestDelegate
    /// The class will have InvokeAsync() methdod that accept HttpContext object
    /// and contains logic for middleware 
    /// </summary>
    public class ErrorMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                
                // if theer are no errors then continue with next middleware
                // in Http Pipeline
                await next(context);
            }
            catch (Exception ex)
            {
                // logic for Error Handling
                await HandleErrorAsync(context, ex);
            }
        }
        /// <summary>
        /// The helper metyhod that will contain logic
        /// </summary>
        /// <returns></returns>
        private async Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            // 1. Define the error code
            context.Response.StatusCode = 500;

            // 2. read the exception and generate the error information object
            var errorInfo = new ErrorInformation()
            {
                ErrorCode = context.Response.StatusCode,
                ErrorMessage = exception.Message
            };

            // 3. serialize the error infromation object into JSON
            // this is because this Middleware is to be executed for WEB API
            var errorMessage = JsonConvert.SerializeObject(errorInfo);

            // 4. Write the Error Response into the HttpContext
            await context.Response.WriteAsync(errorMessage);
        }
    }

    /// <summary>
    /// The Extension class
    /// </summary>
    public static class CustomErrorMiddleware
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            // use the ErrorMiddleware class for Registration in Http Pipeline
            // app.UseMiddleware<T>()
            // T is the class that is ctor injected with RequestDelegate
            // and contains InvokeAsync() method
            // app.UseMiddleware<T>() methdo will add T inside the HttpContext in Http Pipeline
            app.UseMiddleware<ErrorMiddleware>();
        }
    }
}
