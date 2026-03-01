using Microsoft.AspNetCore.Mvc;
using WebApplication6.Filters;

namespace WebApplication6.Controllers
{
    public class FilterController : Controller
    {
        [TestFilter]
        public IActionResult Index()
        {
            return Content("hello");
        }
    }
}
