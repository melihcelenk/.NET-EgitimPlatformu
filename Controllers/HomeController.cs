using EgitimPlatformu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class HomeController : Controller
    {
        melihcelenkmainEntities ent = new melihcelenkmainEntities();
        
        public ActionResult Index()
        {
            AnasayfaDTO obj = new AnasayfaDTO();
            obj.icerik = ent.Icerikler.OrderByDescending(o=>o.IcerikId).Take(4).ToList();
            obj.kullanici = ent.Kullanicilar.OrderByDescending(o => o.KullaniciID).Take(7).ToList();
            obj.kullanicirol = ent.KullaniciRol.OrderByDescending(o=>o.KullaniciID).Take(7).ToList();
            return View(obj);
        }

        public ActionResult CikisYap()
        {
            if(Session["Admin"] != null)
            { 
                if (Session["Admin"].ToString() == "1")
                {
                    Session["Admin"] = "0";
                }
            }
            if (Session["UyeGiris"] != null)
            {
                if (Session["UyeGiris"].ToString() == "1")
                {
                    Session["UyeGiris"] = "0";
                    Session["KullaniciAdi"] = null;
                }
            }

            return Redirect("~/Home/Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
   

        public ActionResult Profil(string username)
        {
            ViewBag.Message = "Your profil page.";
            Kullanicilar kullanici = new Kullanicilar();
            kullanici = ent.Kullanicilar.Where(x => x.KullaniciAdi.ToString() == username.ToString()).ToList().First();
            return View(kullanici);
        }
        public ActionResult Icerik(int id)
        {
            ViewBag.Message = "İçerik Sayfası";
            Icerikler icerik = new Icerikler();
            icerik = ent.Icerikler.Where(x => x.IcerikId == id).ToList().First();
            return View(icerik);
        }

    }
    public class AnasayfaDTO
    {
        public List<Icerikler> icerik { get; set; }
        public List<Kullanicilar> kullanici { get; set; }
        public List<KullaniciRol> kullanicirol { get; set; }
        public List<AnlatimSekilleri> anlatim { get; set; }
        public List<Konular> konular { get; set; }
    }
}