using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;

namespace WebApplication5.Filters
{
    public class LoggingFilter : Attribute, IAsyncActionFilter
    {
        private readonly ILogger<LoggingFilter> _logger;

        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // before action
            var actionName = context.ActionDescriptor.DisplayName;
            //_logger.LogInformation($"Log Info before action : {actionName}");  

            Console.WriteLine("Logfilter Before");
                
            await next();


            // after action
            Console.WriteLine("Logfilter After");

            //_logger.LogDebug($"Log Info after action : {actionName}");


        }
    }
}
