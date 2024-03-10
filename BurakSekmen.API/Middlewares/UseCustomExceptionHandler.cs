using System.Text.Json;
using BurakSekmen.Core.DTOs;
using BurakSekmen.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace BurakSekmen.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {

        public static void  UseCustomException(this IApplicationBuilder app)
        {

            app.UseExceptionHandler(configure =>
                {
                    configure.Run(async context =>
                    {
                        context.Response.ContentType = "application/json";

                        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                        var StatusCode = exceptionHandlerPathFeature.Error switch
                        {
                            ClientSideExeception => 400,
                            NotFoundExecption => 404,
                            _ => 500
                        };

                        context.Response.StatusCode = StatusCode;

                        var response = CustomeResponseDto<NoContentDto>.Fail(exceptionHandlerPathFeature.Error.Message, StatusCode);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                    });
                }
            );
         
        }
    }
}
