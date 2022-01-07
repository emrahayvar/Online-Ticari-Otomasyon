using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicari.Models.Siniflar;

namespace MvcOnlineTicari.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler =c.Personels.ToList();
            return View(degerler);
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> degerler1 = (from x in c.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.Departmanid.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        public ActionResult PersonelGetir(int id)
        {
             List<SelectListItem> degerler1 = (from x in c.Departmans.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.Departmanid.ToString()
                                              }).ToList();
            ViewBag.dgr1 = degerler1;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir", prs);

        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = c.Personels.Find(p.Personelid);
            prsn.PersonelAd = p.PersonelAd;
            prsn.PersonelSoyad = p.PersonelSoyad;
            prsn.PersonelGorsel = p.PersonelGorsel;
            prsn.Departmanid = p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}