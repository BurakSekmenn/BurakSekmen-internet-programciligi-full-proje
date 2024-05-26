using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
