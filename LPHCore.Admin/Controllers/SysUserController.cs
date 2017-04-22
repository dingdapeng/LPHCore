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
    public class SysUserController : Controller
    {
        private readonly LPHdbContext _context;

        public SysUserController(LPHdbContext context)
        {
            _context = context;    
        }

        // GET: SysUser
        public async Task<IActionResult> Index()
        {
            return View(await _context.SysUser.ToListAsync());
        }

        // GET: SysUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysUser = await _context.SysUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysUser == null)
            {
                return NotFound();
            }

            return View(sysUser);
        }

        // GET: SysUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SysUser/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,PassWord,TrueName,CreatTime,Status")] SysUser sysUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sysUser);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sysUser);
        }

        // GET: SysUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysUser = await _context.SysUser.SingleOrDefaultAsync(m => m.Id == id);
            if (sysUser == null)
            {
                return NotFound();
            }
            return View(sysUser);
        }

        // POST: SysUser/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,PassWord,TrueName,CreatTime,Status")] SysUser sysUser)
        {
            if (id != sysUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sysUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SysUserExists(sysUser.Id))
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
            return View(sysUser);
        }

        // GET: SysUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sysUser = await _context.SysUser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sysUser == null)
            {
                return NotFound();
            }

            return View(sysUser);
        }

        // POST: SysUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sysUser = await _context.SysUser.SingleOrDefaultAsync(m => m.Id == id);
            _context.SysUser.Remove(sysUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SysUserExists(int id)
        {
            return _context.SysUser.Any(e => e.Id == id);
        }
    }
}
