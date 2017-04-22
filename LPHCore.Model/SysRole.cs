using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class SysRole
    {
        public SysRole()
        {
            SysRoleSysPermissin = new HashSet<SysRoleSysPermissin>();
            SysUserSysRole = new HashSet<SysUserSysRole>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<SysRoleSysPermissin> SysRoleSysPermissin { get; set; }
        public virtual ICollection<SysUserSysRole> SysUserSysRole { get; set; }
    }
}
