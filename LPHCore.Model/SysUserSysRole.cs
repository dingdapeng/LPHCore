using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class SysUserSysRole
    {
        public int Id { get; set; }
        public int SysUserId { get; set; }
        public int SysRoleId { get; set; }

        public virtual SysRole SysRole { get; set; }
        public virtual SysUser SysUser { get; set; }
    }
}
