using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LPHCore.Admin.Models;
using LPHCore.Model;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace LPHCore.Admin.Controllers
{
    public class AccountController : Controller
    {
        LPHdbContext db = new LPHdbContext();

        public AccountController()
        {

        }


        [Authorize]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]//����������֤�û����в���
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                SysUser user = db.SysUser.Where(x => x.UserName == model.UserName).FirstOrDefault();
                if (user != null)
                {
                    if (user.PassWord == model.Password)
                    {
                        HttpContext.Session.SetString("UserName", user.UserName);
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "�������");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "�˻�������");
                    return View(model);
                }
            }
            return View(model);
        }


        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

    }
}