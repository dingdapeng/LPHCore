using LPHCore.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LPHCore.Admin.Components
{
    public class TopNavbar: ViewComponent
    {
        LPHdbContext db = new LPHdbContext();

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
