using EgitimPlatformu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EgitimPlatformu.Controllers
{
    public class AdminController : Controller
    {

        melihcelenkmainEntities ent = new melihcelenkmainEntities();
        // GET: Admin
        public ActionResult Index()
        {
            AnasayfaDTO obj = new AnasayfaDTO();
            obj.icerik = ent.Icerikler.OrderByDescending(o => o.IcerikId).Take(6).ToList();
            obj.kullanici = ent.Kullanicilar.ToList();
            obj.kullanicirol = ent.KullaniciRol.ToList();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {

            string icerikID = form["icerikID"];

            if (icerikID != null)
            {
                ent.Icerikler.Remove(ent.Icerikler.Where(x => x.IcerikId.ToString() == icerikID).ToList().First());
            }
            ent.SaveChanges();

            return Index();
        }

        public ActionResult Uyeler()
        {
            AnasayfaDTO obj = new AnasayfaDTO();
            obj.icerik = ent.Icerikler.OrderByDescending(o => o.KullaniciID).Take(20).ToList();
            obj.kullanici = ent.Kullanicilar.OrderByDescending(o => o.KullaniciID).Take(20).ToList();
            obj.kullanicirol = ent.KullaniciRol.OrderByDescending(o => o.KullaniciID).Take(20).ToList();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Uyeler(FormCollection form)
        {

            string kullaniciID = form["kullaniciID"];
            if (kullaniciID != null)
            {
                ent.Kullanicilar.Remove(ent.Kullanicilar.Where(x => x.KullaniciID.ToString() == kullaniciID).ToList().First());
            }
            
            
            foreach (var i in ent.KullaniciRol) {
                if(i.KullaniciID.ToString() == kullaniciID)
                {
                    ent.KullaniciRol.Remove(i);
                }
                
            }

            ent.SaveChanges();

            return Uyeler();
        }




        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Session["Admin"]==null || Session["Admin"].ToString() != "1"){
                filterContext.Result = new RedirectResult("~/GirisYap");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}