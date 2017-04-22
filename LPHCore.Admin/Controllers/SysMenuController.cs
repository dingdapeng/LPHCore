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
    public class SysMenuController : Controller
    {
        private readonly LPHdbContext _context;

        public SysMenuController(LPHdbContext context)
        {
            _context = context;
        }

        // GET: SysMenu
        public async Task<IActionResult> Index()
        {
            return View(await _context.SysMenu.ToListAsync());
        }

        // GET: SysMenu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysMenu = await _context.SysMenu
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysMenu == null)
            {
                return NotFound();
            }

            return View(sysMenu);
        }

        // GET: SysMenu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SysMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentId,Url,MenuName,Seq")] SysMenu sysMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sysMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sysMenu);
        }

        // GET: SysMenu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysMenu = await _context.SysMenu.SingleOrDefaultAsync(m => m.Id == id);
            if (sysMenu == null)
            {
                return NotFound();
            }
            return View(sysMenu);
        }

        // POST: SysMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentId,Url,MenuName,Seq")] SysMenu sysMenu)
        {
            if (id != sysMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sysMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SysMenuExists(sysMenu.Id))
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
            return View(sysMenu);
        }

        // GET: SysMenu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysMenu = await _context.SysMenu
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysMenu == null)
            {
                return NotFound();
            }

            return View(sysMenu);
        }

        // POST: SysMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sysMenu = await _context.SysMenu.SingleOrDefaultAsync(m => m.Id == id);
            _context.SysMenu.Remove(sysMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SysMenuExists(int id)
        {
            return _context.SysMenu.Any(e => e.Id == id);
        }
    }
}
