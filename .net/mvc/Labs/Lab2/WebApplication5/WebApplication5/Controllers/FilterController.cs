using Microsoft.AspNetCore.Mvc;
using WebApplication5.Filters;

namespace WebApplication5.Controllers
{
    public class FilterController : Controller
    {
        [TypeFilter(typeof(LoggingFilter))]
        [TestFilter]
        public IActionResult Index()
        {
            return Content("Logggggging");
        }
    }
}
