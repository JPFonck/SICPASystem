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
    }
}
