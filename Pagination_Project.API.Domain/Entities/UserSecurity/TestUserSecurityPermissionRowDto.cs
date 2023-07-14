using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Entities
{
    public class TestUserSecurityPermissionRowDto : IEquatable<TestUserSecurityPermissionRowDto>
    {
        public Guid testUserSecurityPermissionRowID { get; set; }

        public string Name { get; set; }

        public Guid? Parent { get; set; }

        public string Path { get; set; }

        public bool Equals(TestUserSecurityPermissionRowDto other)
        {
            if (testUserSecurityPermissionRowID == other.testUserSecurityPermissionRowID &&
                Name == other.Name &&
                Parent == other.Parent &&
                Path == other.Path)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            int hashSecurityPermissionRowId = testUserSecurityPermissionRowID == Guid.Empty ? 0 : testUserSecurityPermissionRowID.GetHashCode();
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashParent = !Parent.HasValue ? 0 : Parent.GetHashCode();
            int hashPath = Path == null ? 0 : Path.GetHashCode();

            return hashSecurityPermissionRowId ^ hashName ^ hashParent ^ hashPath;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TestUserSecurityPermissionRowDto);
        }
    }
}
