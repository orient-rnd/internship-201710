using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interns2.Domain.Enum
{
    public enum UserType
    {
        [Description("Guest")]
        Guest = 0,

        [Description("Member")]
        Member = 1,

        [Description("Administrator")]
        Administrator = 2,

        [Description("Manager")]
        Manager = 3,

        [Description("AgencyAdmin")]
        AgencyAdmin = 4,

        [Description("AgencyClient")]
        AgencyClient = 5,

        [Description("AgencyEmployee")]
        AgencyEmployee = 6
    }
}