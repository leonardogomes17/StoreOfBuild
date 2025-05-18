using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreOfBuild.Domain
{
    public interface IManager
    {
        Task<bool> CreateAsync(string email, string password, string role);

        List<IUser> ListAll();
    }
}