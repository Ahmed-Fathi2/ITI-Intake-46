using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication5.Filters
{
    public class TestFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Logfilter Before");

            await next();


            // after action
            Console.WriteLine("Logfilter After");
        }
    }
}
