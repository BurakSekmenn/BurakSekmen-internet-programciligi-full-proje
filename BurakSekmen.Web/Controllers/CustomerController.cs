using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.Web.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
