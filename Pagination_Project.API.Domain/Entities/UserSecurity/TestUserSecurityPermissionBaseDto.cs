using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class TestUserSecurityPermissionBaseDto
    {
        public Guid testUserSecurityPermissionID { get; set; }

        public TestUserSecurityPermissionColumnDto SecurityPermissionColumn { get; set; }
    }
}
