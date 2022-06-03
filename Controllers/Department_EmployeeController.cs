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
    public class Department_EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string currentUser;
        private DateTime now;

        public Department_EmployeeController(ApplicationDbContext context)
        {
            _context = context;
            currentUser = Environment.MachineName;
            now = DateTime.Now;
        }

        // GET: Department_Employee
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Department_Employees.Include(d => d.Department).Include(d => d.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Department_Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department_EmployeeModel = await _context.Department_Employees
                .Include(d => d.Department)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department_EmployeeModel == null)
            {
                return NotFound();
            }

            return View(department_EmployeeModel);
        }

        // GET: Department_Employee/Create
        public IActionResult Create()
        {
            ViewData["id_department"] = new SelectList(_context.Department, "Id", "name");
            ViewData["id_employee"] = new SelectList(_context.Employee, "Id", "name");
            return View();
        }

        // POST: Department_Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department_EmployeeModel department_EmployeeModel)
        {
            department_EmployeeModel.created_by = currentUser;
            department_EmployeeModel.created_date = now;

            department_EmployeeModel.modified_by = currentUser;
            department_EmployeeModel.modified_date = now;

            if (ModelState.IsValid)
            {
                _context.Add(department_EmployeeModel);
                await _context.SaveChangesAsync();
                TempData["mensaje"] = "Assignment Saved";
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_department"] = new SelectList(_context.Department, "Id", "name", department_EmployeeModel.id_department);
            ViewData["id_employee"] = new SelectList(_context.Employee, "Id", "name", department_EmployeeModel.id_employee);
            return View(department_EmployeeModel);
        }

        // GET: Department_Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department_EmployeeModel = await _context.Department_Employees.FindAsync(id);
            if (department_EmployeeModel == null)
            {
                return NotFound();
            }
            ViewData["id_department"] = new SelectList(_context.Department, "Id", "name", department_EmployeeModel.id_department);
            ViewData["id_employee"] = new SelectList(_context.Employee, "Id", "name", department_EmployeeModel.id_employee);
            return View(department_EmployeeModel);
        }

        // POST: Department_Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Department_EmployeeModel department_EmployeeModel)
        {
            if (id != department_EmployeeModel.Id)
            {
                return NotFound();
            }

            department_EmployeeModel.modified_by = currentUser;
            department_EmployeeModel.modified_date = now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(department_EmployeeModel);
                    await _context.SaveChangesAsync();
                    TempData["mensaje"] = "Assignment edited";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Department_EmployeeModelExists(department_EmployeeModel.Id))
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
            ViewData["id_department"] = new SelectList(_context.Department, "Id", "name", department_EmployeeModel.id_department);
            ViewData["id_employee"] = new SelectList(_context.Employee, "Id", "name", department_EmployeeModel.id_employee);
            return View(department_EmployeeModel);
        }

        // GET: Department_Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department_EmployeeModel = await _context.Department_Employees
                .Include(d => d.Department)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (department_EmployeeModel == null)
            {
                return NotFound();
            }

            return View(department_EmployeeModel);
        }

        // POST: Department_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var department_EmployeeModel = await _context.Department_Employees.FindAsync(id);
            _context.Department_Employees.Remove(department_EmployeeModel);
            await _context.SaveChangesAsync();
            TempData["mensaje"] = "Assignment deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool Department_EmployeeModelExists(int id)
        {
            return _context.Department_Employees.Any(e => e.Id == id);
        }
    }
}
