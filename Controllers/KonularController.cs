using EgitimPlatformu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class KonularController : Controller
    {
        melihcelenkmainEntities ent = new melihcelenkmainEntities();
        // GET: Konular
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BilgisayarMuhendisligi()
        {
            AnasayfaDTO obj = new AnasayfaDTO();
            obj.icerik = ent.Icerikler.OrderByDescending(o => o.IcerikId).Where(o=>o.Konular.KonuAdi=="Bilgisayar Mühendisliği").Take(5).ToList();
            obj.kullanici = ent.Kullanicilar.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.kullanicirol = ent.KullaniciRol.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.anlatim = ent.AnlatimSekilleri.ToList();
            return View(obj);
        }

        [HttpPost]
        public ActionResult BilgisayarMuhendisligi(FormCollection form)
        {
            AnasayfaDTO obj = new AnasayfaDTO();
            string anlatimsekli = form["anlatimsekli"];
            obj.icerik = ent.Icerikler.OrderByDescending(o => o.IcerikId).Where(o => o.Konular.KonuAdi == "Bilgisayar Mühendisliği" && o.AnlatimSekilleri.AnlatimSekliAdi == anlatimsekli).Take(5).ToList();
            obj.kullanici = ent.Kullanicilar.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.kullanicirol = ent.KullaniciRol.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.anlatim = ent.AnlatimSekilleri.ToList();
            ViewBag.Tur = anlatimsekli;
            return View(obj);
        }

        public ActionResult Muzik()
        {
            AnasayfaDTO obj = new AnasayfaDTO();
            obj.icerik = ent.Icerikler.OrderByDescending(o => o.IcerikId).Where(o => o.Konular.KonuAdi == "Müzik").Take(5).ToList();
            obj.kullanici = ent.Kullanicilar.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.kullanicirol = ent.KullaniciRol.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.anlatim = ent.AnlatimSekilleri.ToList();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Muzik(FormCollection form)
        {
            
            AnasayfaDTO obj = new AnasayfaDTO();
            string anlatimsekli = form["anlatimsekli"];
            obj.icerik = ent.Icerikler.OrderByDescending(o => o.IcerikId).Where(o => o.Konular.KonuAdi == "Müzik" && o.AnlatimSekilleri.AnlatimSekliAdi == anlatimsekli).Take(5).ToList();
            obj.kullanici = ent.Kullanicilar.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.kullanicirol = ent.KullaniciRol.OrderByDescending(o => o.KullaniciID).Take(10).ToList();
            obj.anlatim = ent.AnlatimSekilleri.ToList();
            ViewBag.Tur = anlatimsekli;
            return View(obj);
        }


    }
}