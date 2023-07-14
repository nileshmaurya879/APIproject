using Pagination_Project.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pagination_Project.API.Domain.Helper
{
    public static class SecurityPermissions
    {

        private static TestSecurityRolePermissionForHierarchyDto SecurityRolePermissionForHierarchy(IEnumerable<TestUserSecurityPermissionDto> securityPermissions, IEnumerable<TestSecurityRolePermissionDto> securityRolePermissions, TestUserSecurityPermissionRowDto root,int count)
        {
            var allowedSecurityPermissionIds = securityRolePermissions.Where(x => x.Allowed).Select(x => x.testUserSecurityPermissionID).ToList();
            var securityPermissionHierarchy = new TestSecurityRolePermissionForHierarchyDto
            {
                TestSecurityPermissionRowId = root.testUserSecurityPermissionRowID,
                Name = root.Name,
                Actions = securityPermissions.Where(x => x.SecurityPermissionRow.testUserSecurityPermissionRowID == root.testUserSecurityPermissionRowID)
                                             .OrderBy(x => x.SecurityPermissionColumn.Name)
                                             .Select(x => new TestSecurityPermissionColumnForHierarchyDto
                                             {
                                                 SecurityRolePermissionId = securityRolePermissions.Any(y => y?.testUserSecurityPermissionID == x?.testUserSecurityPermissionID) ? securityRolePermissions.Single(y => y?.testUserSecurityPermissionID == x?.testUserSecurityPermissionID).TestSecurityRolePermissionID : null,
                                                 testUserSecurityPermissionID = x.testUserSecurityPermissionID,
                                                 SecurityPermissionColumn = x.SecurityPermissionColumn,
                                                 Allowed = allowedSecurityPermissionIds.Contains(x.testUserSecurityPermissionID)
                                             }),
                Children = Hierarchy(securityPermissions, securityRolePermissions, root)
            };
            if (!securityPermissionHierarchy.Children.Any())
                securityPermissionHierarchy.Children = null;
            return securityPermissionHierarchy;
        }

        public static IEnumerable<TestSecurityRolePermissionForHierarchyDto> Hierarchy(IEnumerable<TestUserSecurityPermissionDto> securityPermissions, IEnumerable<TestSecurityRolePermissionDto> securityRolePermissions, TestUserSecurityPermissionRowDto root = null)
        {
            var cnt = 0;
            var securityPermissionRowtest = securityPermissions.Select(x => x.SecurityPermissionRow).Distinct().ToList();
           // var securityPermissionRowtest = securityPermissions.Distinct().ToList();

            IOrderedEnumerable<TestUserSecurityPermissionRowDto> items;
            if (root == null)
                items = securityPermissionRowtest.Where(x => !x.Parent.HasValue).OrderBy(x => x.Name);
            else
                items = securityPermissionRowtest.Where(x => x.Parent == root.testUserSecurityPermissionRowID).OrderBy(x => x.Name);

            var securityPermissionsHierarchy = new List<TestSecurityRolePermissionForHierarchyDto>();
            foreach (var item in items)
            {
                var count = cnt++;
                securityPermissionsHierarchy.Add(SecurityRolePermissionForHierarchy(securityPermissions, securityRolePermissions, item, count));
            }
            return securityPermissionsHierarchy;
        }
    }
}
