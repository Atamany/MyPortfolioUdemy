using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class SkillController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var degerler = db.Skills.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skill sk)
        {
            db.Skills.Add(sk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var deger = db.Skills.Find(id);
            db.Skills.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var deger = db.Skills.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill sk)
        {
            var deger = db.Skills.Find(sk.SkillId);
            deger.Title = sk.Title;
            deger.Value = sk.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
