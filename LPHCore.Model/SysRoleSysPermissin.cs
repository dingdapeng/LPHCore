using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class SysRoleSysPermissin
    {
        public int Id { get; set; }
        public int SysRoleId { get; set; }
        public int SysPermissinId { get; set; }

        public virtual SysPermissin SysPermissin { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
