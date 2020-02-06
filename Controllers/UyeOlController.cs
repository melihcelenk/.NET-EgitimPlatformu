using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EgitimPlatformu.Models;

namespace EgitimPlatformu.Controllers
{
    public class UyeOlController : Controller
    {
        // GET: UyeOl
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            melihcelenkmainEntities db = new melihcelenkmainEntities();
            //AnasayfaDTO obj = new AnasayfaDTO();
            Kullanicilar model = new Kullanicilar();
            KullaniciRol rol = new KullaniciRol();
            //obj.kullanicirol = db.KullaniciRol.ToList();

            rol.KullaniciID = (db.Kullanicilar.ToList().Last().KullaniciID) + 1;
            rol.RolID = 2;
            model.AdSoyad = form["AdSoyad"];
            model.KullaniciAdi = form["KullaniciAdi"];
            model.Parola = form["Parola"];
            model.OlusturulmaTarihi = DateTime.Now;
            
            db.Kullanicilar.Add(model);
            db.SaveChanges();
            db.KullaniciRol.Add(rol);
            db.SaveChanges();
            return View();
        }
 


       
    }
}