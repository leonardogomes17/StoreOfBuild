using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain
{
    public interface IAuthentication
    {
        Task<bool> Authenticate(string email, string password);

        Task Logout();
    }
}