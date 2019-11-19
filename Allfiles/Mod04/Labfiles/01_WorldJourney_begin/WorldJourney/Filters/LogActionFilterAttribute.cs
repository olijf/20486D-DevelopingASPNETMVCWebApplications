using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WorldJourney.Filters
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        private IHostingEnvironment _environment;
        private string _contentRootPath;
        private string _logPath;
        private string _fileName;
        private string _fullPath;
        public LogActionFilterAttribute(IHostingEnvironment environment)
        {
            _environment = environment;
            _contentRootPath = _environment.ContentRootPath;
            _logPath = Path.Combine(_contentRootPath, @"LogFile\");
            _fileName = $"log {DateTime.Now.ToString("MM-dd-yyyy-H-mm")}.txt";
            _fullPath = Path.Combine(_logPath, _fileName);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Directory.CreateDirectory(_logPath);
            var actionName = filterContext.ActionDescriptor.RouteValues["action"];
            var controllerName = filterContext.ActionDescriptor.RouteValues["controller"];
            using (var fs = new FileStream(_fullPath, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"The action {actionName} in {controllerName} controller started, event fired: OnActionExecuting");
                }
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            using (var fs = new FileStream(_fullPath, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"The action {actionName} in {controllerName} controller finished, event fired: OnActionExecuted");
                }
            }
            base.OnActionExecuted(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var actionName = context.ActionDescriptor.RouteValues["action"];
            var controllerName = context.ActionDescriptor.RouteValues["controller"];
            var result = (ViewResult)context.Result;
            using (var fs = new FileStream(_fullPath, FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"The action {actionName} in {controllerName} controller has the following viewData : {result.ViewData.Values.FirstOrDefault()}, event fired: OnResultExecuted");
                }
            }
            base.OnResultExecuted(context);
        }
    }
}
