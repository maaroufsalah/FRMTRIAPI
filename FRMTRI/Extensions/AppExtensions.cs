using Application.Constants;
using Application.Exceptions;
using FRMTRI.Helper;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRMTRI.Extensions
{
    public static class AppExtensions
    {

        /// Get exception full message
        public static (string message, string innerMessage) GetFullMessage(this Exception ex)
        {
            return (ex.Message, ex.InnerException?.Message ?? null);
        }

        // Get controller && action name
        public static (string controllerName, string actionName) GetActionFullName(this Controller controller)
        {
            return (controller.ControllerContext.RouteData.Values["controller"].ToString(), controller.ControllerContext.RouteData.Values["action"].ToString());
        }

        // Get exception display message
        public static string GetDisplayMessage(this Exception ex)
        {
            if (ex.GetType() == typeof(LogicalException))
                return ex.Message;
            else
                return ErrorMessage.SERVICE_UNAVAILABLE;
        }

        // Log error message with ILogger
        public static void LogError(this ILogger logger, Exception exception, ControllerBase controller)
        {
            if (exception.GetType() != typeof(ValidationException) && exception.GetType() != typeof(LogicalException))
                logger.LogError(LogMessage.FormatMessage(exception, controller));
        }

        // Get Json message for UI
        public static ActionResult GetJsonMessage(this Controller controller, string messageText, string messageType, bool success = true, object data = null/*, string htmlContent = null*/)
        {
            return new JsonResult(new
            {
               Message = new MessageUI(messageText, messageType.ToLower(), messageType),
               Data = data,
               Success = success,
                //HtmlContent = htmlContent,
            });
        }

    }
}
