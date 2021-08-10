using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using QuizApp.API.Errors;
using QuizApp.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizApp.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            context.Response.ContentType = "application/json";
            int statusCode = StatusCodes.Status500InternalServerError;

            ApiResponse apiResponse = null;
            var result = string.Empty;

            //Handle custom exceptions
            switch(ex)
            {
                case NotFoundException notFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    apiResponse = new ApiResponse(statusCode, notFoundException.Message);
                    break;
                case ValidationException validationException:
                    statusCode = StatusCodes.Status400BadRequest;
                    apiResponse =
                        new ApiValidationErrorResponse(statusCode)
                        {
                            Errors = validationException.ValidationErrors.Select(
                                x => new ApiValidationError { Property = x.Key, Errors = x.Value.ToArray()})
                        };
                    break;
            }

            context.Response.StatusCode = statusCode;

            if (apiResponse is null)
            {
                apiResponse = _env.IsDevelopment()
                    ? new ApiException(StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace.ToString())
                    : new ApiException(StatusCodes.Status500InternalServerError);       
            }
            result = JsonSerializer.Serialize(apiResponse, apiResponse.GetType(), new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await context.Response.WriteAsync(result);


        }
    }
}
