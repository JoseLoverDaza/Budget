using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class DepositController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
