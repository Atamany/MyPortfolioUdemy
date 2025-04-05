using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class FeatureController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        [HttpGet]
        public IActionResult UpdateFeature(int id)
        {
            var deger = db.Features.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateFeature(Feature fe)
        {
            var deger = db.Features.Find(fe.FeatureID);
            deger.Title = fe.Title;
            deger.Description = fe.Description;
            db.SaveChanges();
            return RedirectToAction("Index", "Stats");
        }
    }
}
