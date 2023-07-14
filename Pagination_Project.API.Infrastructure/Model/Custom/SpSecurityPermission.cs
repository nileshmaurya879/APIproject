using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure
{
    [Keyless]
    public class SpSecurityPermission
    {
        public Guid testUserSecurityPermissionID { get; set; }

        public Guid UserSecurityPermissionColumnID { get; set; }

        public string SecurityPermissionColumn { get; set; }

        public Guid testUserSecurityPermissionRowID { get; set; }

        public string SecurityPermissionRow { get; set; }

        public Guid? Parent { get; set; }

        public string Path { get; set; }
    }
}
