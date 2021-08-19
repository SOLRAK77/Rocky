using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category objCat)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(objCat);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(objCat);
        }


        public IActionResult Edit(int Id)
        {
            if(Id == 0 || Id == null)
            {
                return NotFound();
            }

            Category obj = _db.Category.Find(Id);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category objCat)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(objCat);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(objCat);
        }

        public IActionResult Delete(int Id)
        {
            if (Id == 0 && Id == null)
            {
                return NotFound();
            }

            Category obj = _db.Category.Find(Id);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            if (Id != null || Id > 0)
            {
                var obj = _db.Category.Find(Id);
                if (obj != null)
                {
                    _db.Category.Remove(obj);
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }

                
            }
            return NotFound();
        }
    }
}
