using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private string currentUser;
        private DateTime now;

        public EnterprisesController(ApplicationDbContext context)
        {
            _context = context;
            currentUser = Environment.MachineName;
            now = DateTime.Now;
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
           
            enterprise.created_by = currentUser;
            enterprise.created_date = now;

            enterprise.modified_by = currentUser;
            enterprise.modified_date = now;

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
            enterprise.modified_by = currentUser;
            enterprise.modified_date = now;

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

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enterpriseModel = await _context.Enterprise
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enterpriseModel == null)
            {
                return NotFound();
            }

            return View(enterpriseModel);
        }
    }
}
