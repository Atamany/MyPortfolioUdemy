using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class SocialMediaController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var degerler = db.SocialMedias.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia sm)
        {
            db.SocialMedias.Add(sm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var deger = db.SocialMedias.Find(id);
            db.SocialMedias.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var deger = db.SocialMedias.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia sm)
        {
            var deger = db.SocialMedias.Find(sm.SocialMediaId);
            deger.Title = sm.Title;
            deger.URL = sm.URL;
            deger.Icon = sm.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
