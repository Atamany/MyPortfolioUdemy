using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class LayoutController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
