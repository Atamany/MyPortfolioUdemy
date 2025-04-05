using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult ExperienceList()
        {
            var degerler = db.Experiences.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExperience(Experience ex)
        {
            db.Experiences.Add(ex);
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
        public IActionResult DeleteExperience(int id)
        {
            var deger = db.Experiences.Find(id);
            db.Experiences.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var deger = db.Experiences.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience ex)
        {
            var deger = db.Experiences.Find(ex.ExperienceId);
            deger.Head = ex.Head;
            deger.Title = ex.Title;
            deger.Date = ex.Date;
            deger.Description = ex.Description;
            db.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}
