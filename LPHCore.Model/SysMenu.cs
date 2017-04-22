using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class SysMenu
    {
        public SysMenu()
        {
            SysPermissinSysMenu = new HashSet<SysPermissinSysMenu>();
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Url { get; set; }
        public string MenuName { get; set; }
        public int Seq { get; set; }

        public virtual ICollection<SysPermissinSysMenu> SysPermissinSysMenu { get; set; }
    }
}
