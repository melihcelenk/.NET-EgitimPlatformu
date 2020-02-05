using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EgitimPlatformu.Models;

namespace EgitimPlatformu.Controllers
{
    public class IcerikEkleController : Controller
    {
        // GET: UyeOl
        public ActionResult Index()
        {
            AnasayfaDTO obj = new AnasayfaDTO();

            melihcelenkmainEntities db = new melihcelenkmainEntities();

            obj.kullanici = db.Kullanicilar.ToList();
            obj.anlatim = db.AnlatimSekilleri.ToList();
            obj.konular = db.Konular.ToList();
            return View(obj);
        }


        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            AnasayfaDTO obj = new AnasayfaDTO();
            
            melihcelenkmainEntities db = new melihcelenkmainEntities();

            obj.kullanici = db.Kullanicilar.ToList();
            obj.anlatim = db.AnlatimSekilleri.ToList();
            obj.konular = db.Konular.ToList();

            Icerikler icerik = new Icerikler();
         
            icerik.IcerikAd = form["IcerikAd"];
            icerik.Aciklama = form["Aciklama"];
            icerik.GonderimTarihi = DateTime.Now;
            icerik.KonuId = obj.konular.Where(x => x.KonuAdi == form["KonuAdi"]).First().KonuId;
            icerik.AnlatimSekliId = obj.anlatim.Where(x => x.AnlatimSekliAdi == form["AnlatimSekliAdi"]).First().AnlatimSekliId;
            icerik.KullaniciID = obj.kullanici.Where(x => x.KullaniciAdi == Session["KullaniciAdi"].ToString()).First().KullaniciID;

            db.Icerikler.Add(icerik);
            db.SaveChanges();

            return View(obj);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["UyeGiris"] == null || Session["UyeGiris"].ToString() != "1")
            {
                filterContext.Result = new RedirectResult("~/GirisYap");
                return;
            }
            base.OnActionExecuting(filterContext);
        }


    }
}