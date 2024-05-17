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
    public class DocumentsController : Controller
    {
        private readonly WebsiteNoiBoCongTyContext _context;

        public DocumentsController(WebsiteNoiBoCongTyContext context)
        {
            _context = context;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
              return _context.Document != null ? 
                          View(await _context.Document.ToListAsync()) :
                          Problem("Entity set 'WebsiteNoiBoCongTyContext.Document'  is null.");
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Document == null)
            {
                return NotFound();
            }

            var document = await _context.Document
                .FirstOrDefaultAsync(m => m.DocId == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }
    }
}
