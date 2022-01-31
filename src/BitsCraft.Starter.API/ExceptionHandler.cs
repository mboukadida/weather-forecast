﻿using System.Net;
using System.Text.Json;
using BitsCraft.Starter.Domain.SeedWork;

namespace BitsCraft.Starter.API
{
    public sealed class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionHandler(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private Task HandleException(HttpContext context, Exception exception)
        {
            string errorMessage = _env.IsProduction() ? "Internal server error" : "Exception: " + exception.Message;
            Error error = Errors.General.InternalServerError(errorMessage);
            Envelope envelope = Envelope.Error(error, null);
            string result = JsonSerializer.Serialize(envelope);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(result);
        }
    }
}
