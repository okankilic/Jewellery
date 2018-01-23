using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Infrastructure.Core.Constants
{
    public static class Roles
    {
        public const string Admin = "ADMIN";
        public const string Customer = "CUSTOMER";
        public const string Boiler = "BOILER";
        public const string StoneCutter = "STONE_CUTTER";
        public const string Polisher = "POLISHER";

        public const string Any = Customer + "," + Boiler + "," + Polisher + "," + StoneCutter + "," + Admin;
        public const string AdminOrCustomer = Customer + "," + Admin;
        public const string Staff = Boiler + "," + StoneCutter + "," + Polisher;
        public const string AdminAndStaff = Admin + "," + Staff;

        public static IEnumerable<string> GetRoleList()
        {
            var roleList = new List<string>();

            roleList.Add(Admin);
            roleList.Add(Customer);
            roleList.Add(Boiler);
            roleList.Add(StoneCutter);
            roleList.Add(Polisher);

            return roleList;
        }
    }
}
