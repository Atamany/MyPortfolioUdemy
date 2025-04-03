using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
    public class StatsController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = db.Testimonials.Count();
            ViewBag.v2 = db.Messages.Count();
            ViewBag.v3 = db.Messages.Where(x => x.isRead == false).Count();
            ViewBag.v4 = db.Messages.Where(x => x.isRead == true).Count();
            var values = db.Messages.OrderByDescending(x=>x.MessageId).ToList();
            return View(values);
        }
        public IActionResult IsReadToTrue(int id)
        {
            var deger = db.Messages.Find(id);
            deger.isRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult IsReadToFalse(int id)
        {
            var deger = db.Messages.Find(id);
            deger.isRead = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult OpenMessage(int id)
        {
            var deger = db.Messages.Find(id);
            ViewBag.ID = deger.MessageId;
            ViewBag.Gonderen = deger.NameSurname;
            ViewBag.Mail = deger.Email;
            ViewBag.Konu = deger.Subject;
            ViewBag.Mesaj = deger.MessageDetail;
            ViewBag.Tarih = deger.SendDate;
            deger.isRead = true;
            db.SaveChanges();
            return View(deger);
        }
    }
}
