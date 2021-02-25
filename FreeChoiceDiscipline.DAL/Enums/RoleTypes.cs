using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeChoiceDiscipline.Enums
{
    public class RoleType
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Guest = "Guest"; // user did not verified the e-mail and has not access to sign in
    }
}
