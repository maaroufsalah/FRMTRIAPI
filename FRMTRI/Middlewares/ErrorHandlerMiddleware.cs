using Application.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRMTRI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Serilog.ILogger _logger;
        public ErrorHandlerMiddleware(RequestDelegate next)
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
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                string controllerName = context.GetRouteData()?.Values["Controller"].ToString();
                string actionName = context.GetRouteData()?.Values["Action"].ToString();
                response.ContentType = "application/json";
                Response<string> responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };
            }
        }
    }
}
