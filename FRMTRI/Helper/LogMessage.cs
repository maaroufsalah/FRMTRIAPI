using FRMTRI.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FRMTRI.Helper
{
    public class LogMessage
    {
        public static string FormatMessage(string controller, string action, string message)
        {
            return $"{controller} | {action} | {message}";
        }

        public static string FormatMessage(string controller, string action, Exception ex)
        {
            string message = ex.InnerException == null ? ex.Message : $"{ex.InnerException.Message}";
            return $"{controller} |{action} | {message}";
        }

        public static string FormatMessage(Exception exception, ControllerBase controller)
        {
            // Get Controller and Action Name
            string actionName = controller.ControllerContext.ActionDescriptor.ActionName;
            string controllerName = controller.ControllerContext.ActionDescriptor.ControllerName;

            
            // Get Exception and Inner Exception message
            var exceptionFullMessage = exception.GetFullMessage();
            // Build log message
            //var logMessage = $"{actionFullName.controllerName} | {actionFullName.actionName} |";
            //if (exceptionFullMessage.innerMessage is null)
            //    logMessage += $"{exceptionFullMessage.message}";
            //else
            //    logMessage += $"{exceptionFullMessage.message} | {exceptionFullMessage.innerMessage}";

            var logMessage = $"{controllerName} | {actionName} |";
            if (exceptionFullMessage.innerMessage is null)
                logMessage += $"{exceptionFullMessage.message}";
            else
                logMessage += $"{exceptionFullMessage.message} | {exceptionFullMessage.innerMessage}";

            return logMessage;
        }

        public static string FormatMessage(Exception exception, HttpContext context)
        {
            // Get Controller and Action Name
            var controllerName = context.GetRouteData()?.Values["Controller"].ToString();
            string actionName = context.GetRouteData()?.Values["Action"].ToString();
            // Get Exception and Inner Exception message
            var exceptionFullMessage = exception.GetFullMessage();
            // Build log message
            var logMessage = $"{controllerName} | {actionName} |";
            if (exceptionFullMessage.innerMessage is null)
                logMessage += $"{exceptionFullMessage.message}";
            else
                logMessage += $"{exceptionFullMessage.message}";
            return logMessage;
        }
    }
}
