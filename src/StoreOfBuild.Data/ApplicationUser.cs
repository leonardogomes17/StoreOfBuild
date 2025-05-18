using Microsoft.AspNetCore.Identity;
using StoreOfBuild.Domain;

namespace StoreOfBuild.Data
{
    public class ApplicationUser : IdentityUser, IUser
    {
    }
}