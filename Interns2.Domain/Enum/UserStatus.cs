using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interns2.Domain.Enum
{
    public enum UserStatus
    {
        [Description("Pending Approval")]
        PendingApproval = 0,

        [Description("Approved")]
        Approved = 1,

        [Description("Rejected")]
        Rejected = 2
    }
}