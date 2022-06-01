using Microsoft.AspNetCore.Mvc;
using SICPASystem.Data;
using SICPASystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICPASystem.Controllers
{
    public class EnterprisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnterprisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Http Get Index
        public IActionResult Index()
        {
            IEnumerable<EnterpriseModel> listEnterprises = _context.Enterprise;

            return View(listEnterprises);
        }

        //Http Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Http Post Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EnterpriseModel enterprise)
        {
            if (ModelState.IsValid)
            {
                _context.Enterprise.Add(enterprise);
                _context.SaveChanges();

                TempData["mensaje"] = "Enterprise Saved";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Create
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var enterprise = _context.Enterprise.Find(id);

            if (enterprise == null)
            {
                return NotFound();
            }

            return View(enterprise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EnterpriseModel enterprise)
        {
            if (ModelState.IsValid)
            {
                _context.Enterprise.Update(enterprise);
                _context.SaveChanges();

                TempData["mensaje"] = "Enterprise updated";
                return RedirectToAction("Index");
            }
            return View();
        }

        //Http Get Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var enterprise = _context.Enterprise.Find(id);

            if (enterprise == null)
            {
                return NotFound();
            }

            return View(enterprise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEnterprise(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var enterprise = _context.Enterprise.Find(id);

            if(enterprise== null)
            {
                return NotFound();
            }

            _context.Enterprise.Remove(enterprise);
            _context.SaveChanges();

            TempData["mensaje"] = "Enterprise deleted";
            return RedirectToAction("Index");
        }
    }
}
