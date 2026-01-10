using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Identity
{
    public interface ITokenService
    {
        string GenerateJwtToken(ApplicationUser user, List<string> roles);
    }
}
