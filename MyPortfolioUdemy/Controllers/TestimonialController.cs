using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var degerler = db.Testimonials.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial te)
        {
            db.Testimonials.Add(te);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var deger = db.Testimonials.Find(id);
            db.Testimonials.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var deger = db.Testimonials.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial te)
        {
            var deger = db.Testimonials.Find(te.TestimonialId);
            deger.NameSurname = te.NameSurname;
            deger.Title = te.Title;
            deger.Description = te.Description;
            deger.ImageUrl = te.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
