using System;
using System.Collections.Generic;

namespace LPHCore.Model
{
    public partial class SysUser
    {
        public SysUser()
        {
            SysUserSysRole = new HashSet<SysUserSysRole>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string TrueName { get; set; }
        public DateTime CreatTime { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<SysUserSysRole> SysUserSysRole { get; set; }
    }
}
