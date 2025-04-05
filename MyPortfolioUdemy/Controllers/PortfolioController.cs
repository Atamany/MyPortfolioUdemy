using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
    [Authorize]
    public class PortfolioController : Controller
    {
        MyPortfolioContext db = new MyPortfolioContext();
        public IActionResult Index()
        {
            var degerler = db.Portfolios.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio po)
        {
            db.Portfolios.Add(po);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeletePortfolio(int id)
        {
            var deger = db.Portfolios.Find(id);
            db.Portfolios.Remove(deger);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var deger = db.Portfolios.Find(id);
            return View(deger);
        }
        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio po)
        {
            var deger = db.Portfolios.Find(po.PortfolioId);
            deger.Title = po.Title;
            deger.SubTitle = po.SubTitle;
            deger.ImageUrl = po.ImageUrl;
            deger.Url = po.Url;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
