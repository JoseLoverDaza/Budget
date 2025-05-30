using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FinancialInstitutionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
