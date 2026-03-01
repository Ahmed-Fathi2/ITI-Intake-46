using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication6.Filters
{
    public class TestFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("filter before action");

            await next();

            Console.WriteLine("filter after action");
        }
    }
}
