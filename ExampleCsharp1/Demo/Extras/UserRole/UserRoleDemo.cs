using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using TwinfieldApi;
using TwinfieldApi.Extras.UserRoles;

namespace Demo.Extras.UserRole
{
    class UserRoleDemo
    {
        private const string UserRoleType = "ROL";
        private readonly UserRoleService userRoleService;

        public UserRoleDemo(Session session)
        {
            userRoleService = new UserRoleService(session);
        }

        public void Run()
        {
            if (!FindUserRoles())
            {
                return;
            }
            Console.WriteLine();
        }

        private bool FindUserRoles()
        {
            Console.WriteLine("Searching user roles");
            const int searchField = 0;
            var userRoles = userRoleService.FindUserRoles("*", UserRoleType, searchField);
            DisplayUserRoleSummaries(userRoles);
            if (userRoles.Count < 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void DisplayUserRoleSummaries(IEnumerable<UserRoleSummary> userRoles)
        {
            foreach (var userRole in userRoles)
            {
                Console.WriteLine("{0,-16} {1}", userRole.Code, userRole.Name);
            }
            Console.WriteLine();
        }
    }
}
