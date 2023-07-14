using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure.Model
{
    public partial class APIDBContext
    {
        public virtual DbSet<spCustomer> spCustomers { get; set; }
        public virtual DbSet<SpSecurityPermission> spSecurityPermissions { get; set; }
    }
}
