using produkti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace produkti.Controllers
{
    public class productsController : Controller
    {
        // GET: products
        public ActionResult Index()
        {
            produktiEntities1 db = new produktiEntities1();
            List<tabela_produkti> pro = db.tabela_produkti.ToList();

            return View(pro);
        }
        public ActionResult Create()
        {
            produktiEntities1 db = new produktiEntities1();
         //   List<tabela_produkti> pro = db.tabela_produkti.ToList();
            ViewBag.tabela_produkti = db.tabela_produkti.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(tabela_produkti p)
        {
            produktiEntities1 db = new produktiEntities1();

            db.tabela_produkti.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string id)
        {
           produktiEntities1 db = new produktiEntities1();
           tabela_produkti existingProduct = db.tabela_produkti.Where(temp => temp.emri == id).FirstOrDefault();
           // ViewBag.Categories = db.Categories.ToList();
          //  ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }
        [HttpPost]

        public ActionResult Edit(tabela_produkti p)
        {
            produktiEntities1 db = new produktiEntities1();
            tabela_produkti existingProduct = db.tabela_produkti.Where(temp => temp.emri == p.emri).FirstOrDefault();
            existingProduct.cmimi = p.cmimi;
          //  existingProduct.numri = p.numri;
            existingProduct.dataeshtimit = p.dataeshtimit;
            existingProduct.kategoria = p.kategoria;
            existingProduct.pagesa = p.pagesa;
           
            db.SaveChanges();
            return RedirectToAction("Index", "products");
        }
        
            public ActionResult Delete(string id)
        {
                produktiEntities1 db = new produktiEntities1();
                tabela_produkti existingProduct = db.tabela_produkti.Where(temp => temp.emri == id).FirstOrDefault();
            return View(existingProduct);
        }
        [HttpPost]
        public ActionResult Delete(string id, tabela_produkti p)
        {
            produktiEntities1 db = new produktiEntities1();
            tabela_produkti existingProduct = db.tabela_produkti.Where(temp => temp.emri == id).FirstOrDefault();
            db.tabela_produkti.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}