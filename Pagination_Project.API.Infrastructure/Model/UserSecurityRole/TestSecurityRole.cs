using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Infrastructure.Model
{
    public class TestSecurityRole
    {
        public TestSecurityRole(){
            TestSecurityRolePermissions = new HashSet<TestSecurityRolePermission>();
          }
        public Guid? TestSecurityRoleID { get; set; }
        public Guid? TestOrganisationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsDerivedFromTemplate { get; set; }
        public bool IsSysAdmin { get; set; }
        public bool IsMandatory { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid EditedBy { get; set; }
        public DateTime EditedDate { get; set; }
        public bool Active { get; set; }
        public virtual IEnumerable<TestSecurityRolePermission> TestSecurityRolePermissions { get; set; }

    }
}
