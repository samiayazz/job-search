using System.Net;
using JobSearch.WebAPI.Models.Responses;
using JobSearch.Application.Exceptions;
using System.Net.Mime;

namespace JobSearch.WebAPI.Middlewares.Exception;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
        => _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (System.Exception exception)
        {
            var response = context.Response;
            response.ContentType = MediaTypeNames.Application.Json;
            switch (exception)
            {
                case CustomException:
                    // Custom Exception
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException:
                    // Not Found Exception
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // Unhandled Exception
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var customResponse = new GeneralResponse<string>();
            customResponse.Success = false;
            customResponse.Message = $"An exception has occurred! Details: '{exception.Message}'";
            await response.WriteAsJsonAsync(customResponse);
        }
    }
}
