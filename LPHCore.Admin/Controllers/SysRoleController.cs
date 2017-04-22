using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LPHCore.Model;

namespace LPHCore.Admin.Controllers
{
    public class SysRoleController : Controller
    {
        private readonly LPHdbContext _context;

        public SysRoleController(LPHdbContext context)
        {
            _context = context;    
        }

        // GET: SysRole
        public async Task<IActionResult> Index()
        {
            return View(await _context.SysRole.ToListAsync());
        }

        // GET: SysRole/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysRole = await _context.SysRole
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysRole == null)
            {
                return NotFound();
            }

            return View(sysRole);
        }

        // GET: SysRole/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SysRole/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleName")] SysRole sysRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sysRole);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sysRole);
        }

        // GET: SysRole/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysRole = await _context.SysRole.SingleOrDefaultAsync(m => m.Id == id);
            if (sysRole == null)
            {
                return NotFound();
            }
            return View(sysRole);
        }

        // POST: SysRole/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleName")] SysRole sysRole)
        {
            if (id != sysRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sysRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SysRoleExists(sysRole.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(sysRole);
        }

        // GET: SysRole/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysRole = await _context.SysRole
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysRole == null)
            {
                return NotFound();
            }

            return View(sysRole);
        }

        // POST: SysRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sysRole = await _context.SysRole.SingleOrDefaultAsync(m => m.Id == id);
            _context.SysRole.Remove(sysRole);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SysRoleExists(int id)
        {
            return _context.SysRole.Any(e => e.Id == id);
        }
    }
}
