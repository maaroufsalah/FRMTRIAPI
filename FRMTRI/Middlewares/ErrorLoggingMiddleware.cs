using Application.Exceptions;
using FRMTRI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRMTRI.Middlewares
{
    public class ErrorLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;

        public ErrorLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Serilog.Log.ForContext<ErrorHandlerMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //catch (GlobalException error) { throw error; }
            //catch (ValidationException error) { throw error; }
            catch (GlobalException) { throw; }
            catch (ValidationException) { throw; }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                string controllerName = context.GetRouteData()?.Values["Controller"].ToString();
                string actionName = context.GetRouteData()?.Values["Action"].ToString();
                _logger.Error(LogMessage.FormatMessage(controllerName, actionName, error));
                throw;
            }
        }
    }
}
