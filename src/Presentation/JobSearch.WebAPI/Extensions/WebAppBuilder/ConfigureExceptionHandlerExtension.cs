using JobSearch.WebAPI.Middlewares.Exception;
using JobSearch.WebAPI.Models.Responses;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;

namespace JobSearch.WebAPI.Extensions.WebAppBuilder;

public static class ConfigureExceptionHandlerExtension
{
    public static void UseGlobalExceptionHandler(this WebApplication app)
    {
        #region with appBuilder
        /*app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    //Logging

                    context.Response.WriteAsJsonAsync(new GeneralResponse<object>
                    {
                        Data = null,
                        StatusCode = context.Response.StatusCode,
                        Message = $"An error has occurred! Details: '{contextFeature.Error.Message}'"
                    });
                }
            });
        });*/
        #endregion

        // Source: https://hakanguzel.medium.com/asp-net-coreda-global-exception-handling-ec11f90b85ce
        app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
    }
}