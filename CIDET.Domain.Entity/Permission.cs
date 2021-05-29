using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALPHA.Domain.Entity
{
    public class Permission
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string PermissionName { get; set; }
        [Required]
        public List<RolPermission> RolPermissions { get; set; }
    }
}
