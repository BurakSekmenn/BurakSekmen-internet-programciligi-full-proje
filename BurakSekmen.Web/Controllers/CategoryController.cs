using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.Web.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
