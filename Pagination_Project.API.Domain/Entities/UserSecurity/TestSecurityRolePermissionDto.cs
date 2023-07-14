using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class TestSecurityRolePermissionDto
    {
        public Guid TestSecurityRolePermissionID { get; set; }
        public Guid TestSecurityRoleID { get; set; }
        public Guid testUserSecurityPermissionID { get; set; }
        public bool Allowed { get; set; }
        public DateTime EditedDate { get; set; }
    }
}
