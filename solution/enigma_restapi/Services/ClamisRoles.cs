using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace enigma_restapi.Services
{
    public class ClamisRoles
    {

        public const string VISITOR= "Visitor";
        public const string ADMINISTRATOR = "Administrator";
        public const string SUPPORT = "Support";

        public List<Claim> rolesDeAcceso()
        {
            List<Claim> roles = new List<Claim>();

            roles.Add(new Claim(ClaimTypes.Role, VISITOR));
            roles.Add(new Claim(ClaimTypes.Role, ADMINISTRATOR));
            roles.Add(new Claim(ClaimTypes.Role, SUPPORT));

            return roles;

        } 

        public Claim RolVisitor()
        {
            return new Claim(ClaimTypes.Role, VISITOR);
        }

        public Claim RolSupport()
        {
            return new Claim(ClaimTypes.Role, SUPPORT);
        }

        public Claim RolAdministrator()
        {
            return new Claim(ClaimTypes.Role, ADMINISTRATOR);
        }

        public Claim getRol(string rol)
        {
            return new Claim(ClaimTypes.Role, rol);
        }
    }
}
