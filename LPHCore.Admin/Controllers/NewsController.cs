using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using LPHCore.Model;

namespace LPHCore.Admin.Controllers
{
    public class NewsController : Controller
    {
        private readonly LPHdbContext _context;
        private IHostingEnvironment _env;

        public NewsController(LPHdbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var lPHdbContext = _context.News.Include(n => n.Category);
            return View(await lPHdbContext.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,Title,ImgUrl,Contents,Click,Status")] News news)
        {
            if (ModelState.IsValid)
            {
                news.CreateTime = DateTime.Now;
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name", news.CategoryId);
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name", news.CategoryId);
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryId,Title,ImgUrl,Contents,CreateTime,Click,Status,Seq")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.NewsCategory, "Id", "Name", news.CategoryId);
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Category)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.SingleOrDefaultAsync(m => m.Id == id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }

        /// <summary>
        /// 文件上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadFiles()
        {
            string filesPath = "";
            var files = Request.Form.Files;
            string tempPath = "uploadfiles" + '\\' + DateTime.Now.ToString("yyyyMMdd");//相对路径
            string physicPath = _env.WebRootPath + '\\' + tempPath;//物理路径
            if (!Directory.Exists(physicPath))
            {
                Directory.CreateDirectory(physicPath);
            }
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    //文件名字
                    string filesName = DateTime.Now.ToFileTime() + Path.GetExtension(formFile.FileName);
                    //绝对路径
                    string fileFullPath = Path.Combine(physicPath, filesName);
                    using (var stream = new FileStream(fileFullPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);//保存文件
                    }
                    filesPath += tempPath + '\\' + filesName + ',';
                }
            }
            filesPath = filesPath.TrimEnd(',');
            return Ok(new { filesPath });
        }
    }
}
