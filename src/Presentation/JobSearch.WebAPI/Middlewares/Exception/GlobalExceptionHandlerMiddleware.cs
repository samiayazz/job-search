using System.Net;
using System.Net.Mime;
using JobSearch.Application.Exceptions;
using JobSearch.WebAPI.Models.Responses;

namespace JobSearch.WebAPI.Middlewares.Exception
{
    public class GlobalExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (System.Exception exception)
            {
                context.Response.ContentType = MediaTypeNames.Application.Json;
                switch (exception)
                {
                    case CustomException:
                        // Custom Exception
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException:
                        // Not Found Exception
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // Unhandled Exception
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var response = new ApiResponse<string>();
                response.Success = false;
                response.Message = $"Beklenmeyen bir hata oluştu! Detay: '{exception.Message}'";
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}