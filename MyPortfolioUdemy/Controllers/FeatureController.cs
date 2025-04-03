using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    public class FeatureController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var degerler = db.Features.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateFeature(Feature fe)
        {
            db.Features.Add(fe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteFeature(int id)
        {
            var deger = db.Features.Find(id);
            db.Features.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
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
            return RedirectToAction("Index");
        }
    }
}
