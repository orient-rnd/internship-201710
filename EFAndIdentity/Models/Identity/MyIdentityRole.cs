using Microsoft.AspNetCore.Identity;

namespace EFAndIdentity.Models.Identity
{
    public class MyIdentityRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
