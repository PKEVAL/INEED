using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INEED.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterUser(string username, string password, string email);
        Task<string> LoginUser(string username, string password);
    }
}
