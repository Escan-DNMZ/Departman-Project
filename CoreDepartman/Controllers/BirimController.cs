using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreDepartman.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CoreDepartman.Controllers
{
    public class BirimController:Controller
    {
        Context c = new Context();
        [Authorize]
        public IActionResult Index(){
           var degerler = c.Birims.ToList();
           return View(degerler);
       }

       [HttpGet]
       public IActionResult YeniBirim(){
           return View();
       }

       [HttpPost]
       public IActionResult YeniBirim(Birim b){
           c.Birims.Add(b);
           c.SaveChanges();
           return RedirectToAction("Index");
       }

          public IActionResult BirimSil(int id){
           var birim = c.Birims.Find(id);
           c.Birims.Remove(birim);
           c.SaveChanges();
           return RedirectToAction("Index");
       }
       
        public IActionResult BirimGetir(int id){
           var birim = c.Birims.Find(id);
           return View("BirimGetir",birim);
       }

        public IActionResult BirimGuncelle(Birim d){
           var birim = c.Birims.Find(d.BirimID);
            birim.BirimAd = d.BirimAd;
           c.SaveChanges();
           return RedirectToAction("Index");
       }
             
    }
}