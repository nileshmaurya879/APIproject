using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class TestSecurityPermissionColumnForHierarchyDto: TestUserSecurityPermissionBaseDto
    {
        public Guid? SecurityRolePermissionId { get; set; }

        public bool Allowed { get; set; }
    }
}
