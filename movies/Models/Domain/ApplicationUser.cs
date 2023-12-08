using Microsoft.AspNetCore.Identity;

namespace movies.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
       
    }
}
