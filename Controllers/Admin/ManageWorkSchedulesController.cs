using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteNoiBoCongTy.Data;
using WebsiteNoiBoCongTy.Models;

namespace WebsiteNoiBoCongTy.Controllers.Admin
{
    public class ManageWorkSchedulesController : Controller
    {
        private readonly WebsiteNoiBoCongTyContext _context;

        public ManageWorkSchedulesController(WebsiteNoiBoCongTyContext context)
        {
            _context = context;
        }

        // GET: ManageWorkSchedules
        public async Task<IActionResult> Index()
        {
            var websiteNoiBoCongTyContext = _context.WorkSchedule.Include(w => w.Department);
            return View(await websiteNoiBoCongTyContext.ToListAsync());
        }

        // GET: ManageWorkSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WorkSchedule == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedule
                .Include(w => w.Department)
                .FirstOrDefaultAsync(m => m.WsgId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            return View(workSchedule);
        }

        // GET: ManageWorkSchedules/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name");
            return View();
        }

        // POST: ManageWorkSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WsgId,Title,Content,StartTime,Deadline,DepartmentId")] WorkSchedule workSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", workSchedule.DepartmentId);
            return View(workSchedule);
        }

        // GET: ManageWorkSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WorkSchedule == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedule.FindAsync(id);
            if (workSchedule == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", workSchedule.DepartmentId);
            return View(workSchedule);
        }

        // POST: ManageWorkSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WsgId,Title,Content,StartTime,Deadline,DepartmentId")] WorkSchedule workSchedule)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkScheduleExists(workSchedule.WsgId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", workSchedule.DepartmentId);
            return View(workSchedule);
        }

        // GET: ManageWorkSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WorkSchedule == null)
            {
                return NotFound();
            }

            var workSchedule = await _context.WorkSchedule
                .Include(w => w.Department)
                .FirstOrDefaultAsync(m => m.WsgId == id);
            if (workSchedule == null)
            {
                return NotFound();
            }

            return View(workSchedule);
        }

        // POST: ManageWorkSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WorkSchedule == null)
            {
                return Problem("Entity set 'WebsiteNoiBoCongTyContext.WorkSchedule'  is null.");
            }
            var workSchedule = await _context.WorkSchedule.FindAsync(id);
            if (workSchedule != null)
            {
                _context.WorkSchedule.Remove(workSchedule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkScheduleExists(int id)
        {
          return (_context.WorkSchedule?.Any(e => e.WsgId == id)).GetValueOrDefault();
        }
    }
}
