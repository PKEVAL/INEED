using INEED.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INEED.Common.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
