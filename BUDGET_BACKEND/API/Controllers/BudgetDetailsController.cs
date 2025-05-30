using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BudgetDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
