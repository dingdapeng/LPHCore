using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class SysPermissin
    {
        public SysPermissin()
        {
            SysPermissinSysMenu = new HashSet<SysPermissinSysMenu>();
            SysRoleSysPermissin = new HashSet<SysRoleSysPermissin>();
        }

        public int Id { get; set; }
        public string Types { get; set; }

        public virtual ICollection<SysPermissinSysMenu> SysPermissinSysMenu { get; set; }
        public virtual ICollection<SysRoleSysPermissin> SysRoleSysPermissin { get; set; }
    }
}
