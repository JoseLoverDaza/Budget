using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
