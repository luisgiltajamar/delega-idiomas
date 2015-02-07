using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace MvcCompleto.Seguridad
{
   public class IdentidadPersonalizado:IIdentity
    {
       public string Name {
           get { return Email; }
       }
       public string AuthenticationType {
           get { return Identity.AuthenticationType; } }
       public bool IsAuthenticated {
           get { return Identity.IsAuthenticated; } }

       public String Nombre { get; set; }
       public String Apellidos { get; set; }
       public String Rol { get; set; }
       public int IdUsuario { get; set; }
       public String Email { get; set; }
       public IIdentity Identity { get; set; }


       public IdentidadPersonalizado(IIdentity identity)
       {
           Identity = identity;
           var us = (UsuarioMembership) Membership.GetUser(Identity.Name);
           Nombre = us.Nombre;
           Apellidos = us.Apellidos;
           Rol = us.Rol;
           IdUsuario = us.IdUsuario;
           Email = us.Login;
       }

    }


}
