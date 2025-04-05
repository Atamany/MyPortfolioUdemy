using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var deger = db.Contacts.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdateContact(Contact co)
        {
            var deger = db.Contacts.Find(co.ContactId);
            deger.Title = co.Title;
            deger.Description = co.Description;
            deger.Phone1 = co.Phone1;
            deger.Phone2 = co.Phone2;
            deger.Email1 = co.Email1;
            deger.Email2 = co.Email2;
            deger.Address = co.Address;
            db.SaveChanges();
            return RedirectToAction("Index","Stats");
        }
    }
}
