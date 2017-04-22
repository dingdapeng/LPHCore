using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LPHCore.Model;

namespace LPHCore.API.Controllers
{
    [Produces("application/json")]
    [Route("api/SysUser")]
    public class SysUserController : Controller
    {
        private readonly LPHdbContext _context;

        public SysUserController(LPHdbContext context)
        {
            _context = context;
        }

        // GET: api/SysUser
        [HttpGet]
        public IEnumerable<SysUser> GetSysUser()
        {
            return _context.SysUser;
        }

        // GET: api/SysUser/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSysUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sysUser = await _context.SysUser.SingleOrDefaultAsync(m => m.Id == id);

            if (sysUser == null)
            {
                return NotFound();
            }

            return Ok(sysUser);
        }

        // PUT: api/SysUser/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSysUser([FromRoute] int id, [FromBody] SysUser sysUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sysUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(sysUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SysUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SysUser
        [HttpPost]
        public async Task<IActionResult> PostSysUser([FromBody] SysUser sysUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SysUser.Add(sysUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSysUser", new { id = sysUser.Id }, sysUser);
        }

        // DELETE: api/SysUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSysUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sysUser = await _context.SysUser.SingleOrDefaultAsync(m => m.Id == id);
            if (sysUser == null)
            {
                return NotFound();
            }

            _context.SysUser.Remove(sysUser);
            await _context.SaveChangesAsync();

            return Ok(sysUser);
        }

        private bool SysUserExists(int id)
        {
            return _context.SysUser.Any(e => e.Id == id);
        }
    }
}