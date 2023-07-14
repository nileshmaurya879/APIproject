using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class UserSecurityRoleDto
    {
        public Guid? TestSecurityRoleID { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Guid? TestOrganisationID { get; set; }
        public string Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
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
        public IEnumerable<TestSecurityRolePermissionForHierarchyDto> SecurityRolePermissions { get; set; }
    }
}
