using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SICPASystem.Data;
using SICPASystem.Models;

namespace SICPASystem.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string currentUser;
        private DateTime now;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
            currentUser = Environment.MachineName;
            now = DateTime.Now;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Department.Include(d => d.Enterprise);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Department
                .Include(d => d.Enterprise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["id_enterprise"] = new SelectList(_context.Enterprise, "Id", "name");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentModel departmentModel)
        {
            departmentModel.created_by = currentUser;
            departmentModel.created_date = now;

            departmentModel.modified_by = currentUser;
            departmentModel.modified_date = now;

            if (ModelState.IsValid)
            {
                _context.Add(departmentModel);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Department Saved";
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_enterprise"] = new SelectList(_context.Enterprise, "Id", "name", departmentModel.id_enterprise);
            return View(departmentModel);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Department.FindAsync(id);
            if (departmentModel == null)
            {
                return NotFound();
            }
            ViewData["id_enterprise"] = new SelectList(_context.Enterprise, "Id", "name", departmentModel.id_enterprise);
            return View(departmentModel);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentModel departmentModel)
        {
            if (id != departmentModel.Id)
            {
                return NotFound();
            }

            departmentModel.modified_by = currentUser;
            departmentModel.modified_date = now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentModel);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "Department updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentModelExists(departmentModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_enterprise"] = new SelectList(_context.Enterprise, "Id", "name", departmentModel.id_enterprise);
            return View(departmentModel);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentModel = await _context.Department
                .Include(d => d.Enterprise)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentModel == null)
            {
                return NotFound();
            }

            return View(departmentModel);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departmentModel = await _context.Department.FindAsync(id);
            _context.Department.Remove(departmentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentModelExists(int id)
        {
            return _context.Department.Any(e => e.Id == id);
        }
    }
}
