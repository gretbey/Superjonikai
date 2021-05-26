using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Diagnostics;
using System.IO;

namespace Superjonikai.Model.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
            => Log("OnActionExecuting", filterContext.RouteData);


        private void Log(string methodName, RouteData routeData)
        {
            var message = string.Format("{0} | {1} | {2} | controller:{3} | action:{4}", DateTime.Now, "Action Filter Log", methodName, routeData.Values["controller"], routeData.Values["action"]);

            Debug.WriteLine(message, "Action Filter Log");

            var logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "superjonikai_log.txt");
            try
            {
                using StreamWriter logFile = new StreamWriter(logPath, true);
                logFile.WriteLine(message);
                logFile.Close();
            }
            catch
            {
                Console.WriteLine("Exception while trying to log to file");
            }
        }

    }
}
