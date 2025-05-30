using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
