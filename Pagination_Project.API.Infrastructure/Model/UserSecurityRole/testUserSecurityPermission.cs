using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class testUserSecurityPermission
    {
        public Guid testUserSecurityPermissionID { get; set; }
        public Guid testUserSecurityPermissionRowID { get; set; }
        public Guid UserSecurityPermissionColumnID { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EditedDate { get; set; }
        public Guid EditedBy { get; set; }
        public bool Active { get; set; }

    }
}
