using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreDepartman.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CoreDepartman.Controllers
{
    public class PersonelController:Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index(){
            var degerler = c.Personels.Include(x=>x.Birim).ToList();

            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel(){
            List<SelectListItem> degerler =(from x in c.Birims.ToList()
                                            select new SelectListItem{
                                                Text=x.BirimAd,
                                                Value=x.BirimID.ToString()
                                            }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        public IActionResult PersonelSil(int id)
        {
            var per = c.Personels.Find(id);
            c.Personels.Remove(per);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
       public IActionResult PersonelGetir(int id){
           
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()

                                             }).ToList();
            ViewBag.dgr = degerler;
            var getir = c.Personels.Find(id);
            return View("PersonelGetir",getir);

       }
         public IActionResult PersonelGuncelle(Personel p)
        {
            
            var per = c.Personels.Find(p.PerId);
            per.Ad = p.Ad;
            per.Soyad = p.Soyad; 
            per.Sehir = p.Sehir; 
            var per1 = c.Birims.Where(x => x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per1;
            per.Birim = p.Birim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}