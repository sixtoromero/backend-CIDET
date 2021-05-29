using System;
using System.Collections.Generic;
using System.Text;

namespace ALPHA.Application.DTO
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public List<RolPermissionDTO> RolPermissions { get; set; }
    }
}
