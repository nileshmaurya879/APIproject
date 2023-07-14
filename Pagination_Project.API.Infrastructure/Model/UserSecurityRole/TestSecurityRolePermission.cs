using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class TestSecurityRolePermission
    {
        public Guid TestSecurityRolePermissionID { get; set; }
        public Guid TestSecurityRoleID { get; set; }
        public Guid testUserSecurityPermissionID { get; set; }
        public bool Allowed { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public bool Active { get; set; }
        public virtual testUserSecurityPermission TestSecurityPermission { get; set; }
    }
}
