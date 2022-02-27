using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace enigma_restapi.Services
{
    public class ClamisRoles
    {

        public List<Claim> rolesDeAcceso()
        {
            List<Claim> roles = new List<Claim>();

            roles.Add(new Claim(ClaimTypes.Role, "Administrator"));
            roles.Add(new Claim(ClaimTypes.Role, "Visitor"));
            roles.Add(new Claim(ClaimTypes.Role, "Support"));

            return roles;

        } 

    }
}
