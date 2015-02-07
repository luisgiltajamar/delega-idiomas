using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using MvcCompleto.Models;

namespace MvcCompleto.Seguridad
{
   public class ProveedorRol:RoleProvider
    {



       public override bool IsUserInRole(string username, string roleName)
       {
           using (var db = new DelegaEntities())
           {
               return db.Usuarios.Any(o => o.email == username && o.rol == roleName);
           }
       }

       public override string[] GetRolesForUser(string username)
       {
           using (var db = new DelegaEntities())
           {
               return db.Usuarios.Where(o => o.email == username).Select(o => o.rol).ToArray();

           }
       }

       public override void CreateRole(string roleName)
       {
           throw new NotImplementedException();
       }

       public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
       {
           throw new NotImplementedException();
       }

       public override bool RoleExists(string roleName)
       {
           throw new NotImplementedException();
       }

       public override void AddUsersToRoles(string[] usernames, string[] roleNames)
       {
           throw new NotImplementedException();
       }

       public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
       {
           throw new NotImplementedException();
       }

       public override string[] GetUsersInRole(string roleName)
       {
           throw new NotImplementedException();
       }

       public override string[] GetAllRoles()
       {
           throw new NotImplementedException();
       }

       public override string[] FindUsersInRole(string roleName, string usernameToMatch)
       {
           throw new NotImplementedException();
       }

       public override string ApplicationName { get; set; }
    }
}
