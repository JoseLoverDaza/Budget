using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BudgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
