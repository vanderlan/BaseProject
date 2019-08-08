﻿using Invest.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Invest.Api.Handler
{
    public class InvestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _env;

        public InvestMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _env = env;
            _loggerFactory = loggerFactory;
            _next = next;

            _logger = _loggerFactory.CreateLogger<InvestMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                if (_next != null)
                {
                    await _next(context);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exception = ex;

            var status = exception is NotFoundException ? HttpStatusCode.NotFound :
                exception is ConflictException ? HttpStatusCode.Conflict :
                exception is UnauthorizedUserException ? HttpStatusCode.Unauthorized :
                exception is DatabaseException ? HttpStatusCode.BadRequest :
                exception is BusinessException ? HttpStatusCode.BadRequest
                : HttpStatusCode.InternalServerError;

            var errorResponse = new ExceptionResponse(exception.Message, NotificationType.Error);

            var msg = exception.Message;
            //var msg = "Ocorreu um erro inesperado. Por favor, contate o suporte para saber mais.";

            if (ex is BusinessException == false && !_env.IsDevelopment())
            {
                errorResponse = new ExceptionResponse(msg, NotificationType.Error);
            }

            if (ex is UnauthorizedUserException)
            {
                errorResponse = new ExceptionResponse(ex.Message, NotificationType.Error);
            }

            var errrorReturn = JsonConvert.SerializeObject(errorResponse);

            _logger.LogError(errrorReturn);

            var retorno = JsonConvert.SerializeObject(errorResponse);

            context.Response.StatusCode = (int)status;
            context.Response.ContentType = @"application/json";
            await context.Response.WriteAsync(retorno);
        }
    }



    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class InvestMiddlewareExtensions
    {
        public static IApplicationBuilder UseInvestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InvestMiddleware>();
        }
    }
}
