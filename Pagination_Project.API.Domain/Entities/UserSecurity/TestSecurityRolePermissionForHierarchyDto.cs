using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class TestSecurityRolePermissionForHierarchyDto
    {
        public Guid TestSecurityPermissionRowId { get; set; }

        public string Name { get; set; }

        public IEnumerable<TestSecurityPermissionColumnForHierarchyDto> Actions { get; set; }

        public IEnumerable<TestSecurityRolePermissionForHierarchyDto> Children { get; set; }
    }
}
