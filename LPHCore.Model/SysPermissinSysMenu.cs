using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class SysPermissinSysMenu
    {
        public int Id { get; set; }
        public int SysPermissinId { get; set; }
        public int SysMenuId { get; set; }

        public virtual SysMenu SysMenu { get; set; }
        public virtual SysPermissin SysPermissin { get; set; }
    }
}
