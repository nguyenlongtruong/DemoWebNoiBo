using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteNoiBoCongTy.Data;
using WebsiteNoiBoCongTy.Models;

namespace WebsiteNoiBoCongTy.Controllers
{
    public class WorkSchedulesController : Controller
    {
        private readonly WebsiteNoiBoCongTyContext _context;

        public WorkSchedulesController(WebsiteNoiBoCongTyContext context)
        {
            _context = context;
        }

        // GET: WorkSchedules
        public async Task<IActionResult> Index()
        {
            String? id = HttpContext.Session.GetString("AccountId");
            var account = await _context.Account.FirstOrDefaultAsync(acc => acc.AccountId.ToString() == id);
            var websiteNoiBoCongTyContext = _context.WorkSchedule.Include(w => w.Department)
                .Where(w=>w.DepartmentId == account.DepartmentId);
            return View(await websiteNoiBoCongTyContext.ToListAsync());
        }

        // GET: WorkSchedules/Details/5
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
    }
}
