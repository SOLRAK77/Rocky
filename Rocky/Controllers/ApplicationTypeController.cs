using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Controllers
{
    public class ApplicationTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType;
            return View(objList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }

            ApplicationType obj = _db.ApplicationType.Find(Id);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == 0 && Id == null)
            {
                return NotFound();
            }

            ApplicationType obj = _db.ApplicationType.Find(Id);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            if (Id != null || Id > 0)
            {
                var obj = _db.ApplicationType.Find(Id);
                if (obj != null)
                {
                    _db.ApplicationType.Remove(obj);
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
