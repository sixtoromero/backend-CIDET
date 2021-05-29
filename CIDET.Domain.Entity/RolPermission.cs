using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALPHA.Domain.Entity
{
    public class RolPermission
    {
        public int Id { get; set; }
        [Required]
        public int RolId { get; set; }
        [Required]
        public int PermissionId { get; set; }
    }
}
