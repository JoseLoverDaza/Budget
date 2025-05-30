using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TypeExpenseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
