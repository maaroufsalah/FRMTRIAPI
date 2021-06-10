using FRMTRI.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRMTRI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void UseErrorLoggingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorLoggingMiddleware>();
        }
    }
}
