using EgitimPlatformu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class GirisYapController : Controller
    {
        melihcelenkmainEntities db = new melihcelenkmainEntities();

        // GET: GirisYap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            string kullaniciAdi = form["KullaniciAdi"];
            string parola = form["Parola"];

            AnasayfaDTO obj = new AnasayfaDTO();
            obj.kullanici = db.Kullanicilar.ToList();
            bool varMi = obj.kullanici.Exists(x => x.KullaniciAdi == kullaniciAdi && x.Parola == parola);
            
            if (varMi)
            {
                bool adminMi = obj.kullanici.Where(x => x.KullaniciAdi == kullaniciAdi && x.Parola == parola).First().KullaniciRol.ToList().Exists(x => x.Roller.RolAdi=="Admin");
                Session["UyeGiris"] = "1";
                Session["KullaniciAdi"] = kullaniciAdi;
                if (adminMi)
                {
                    Session["Admin"] = "1";
                    return Redirect("~/Admin/Index");
                }
                return Redirect("~/Home/Index");
            }
            return Redirect("Index");

            
        }
    }
}