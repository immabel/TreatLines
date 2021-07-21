using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Claims;

namespace TreatLines.BLL.Interfaces
{
    public interface IJwtAuthenticationManager
    {
        string GenerateTokenForClaims(IEnumerable<Claim> userClaims);
    }
}
