using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioUdemy.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult ExperienceList()
        {
            return View();
        }
    }
}
