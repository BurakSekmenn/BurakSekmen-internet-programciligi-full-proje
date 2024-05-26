using Microsoft.AspNetCore.Mvc;

namespace BurakSekmen.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
    }
}
