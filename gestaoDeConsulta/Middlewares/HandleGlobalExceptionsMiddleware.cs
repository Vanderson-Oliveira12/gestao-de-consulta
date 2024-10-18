using gestaoDeConsulta.Models;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace gestaoDeConsulta.Middlewares
{
    public class HandleGlobalExceptionsMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<HandleGlobalExceptionsMiddleware> _logger;

        public HandleGlobalExceptionsMiddleware(RequestDelegate next, ILogger<HandleGlobalExceptionsMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch ( Exception ex ) {

                _logger.LogError($"Tipo do erro: {ex.Message}");

                var response = new
                {
                    Message = "Erro interno do servidor",
                    StatusCode = 500,
                };

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
