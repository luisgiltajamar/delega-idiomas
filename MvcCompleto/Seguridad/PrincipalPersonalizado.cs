using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MvcCompleto.Seguridad
{
   public class PrincipalPersonalizado:IPrincipal
    {
       public bool IsInRole(string role)
       {
           return MiIdentidadPersonalizado.Rol == role;
       }

       public IIdentity Identity { get; private set; }
       public IdentidadPersonalizado MiIdentidadPersonalizado {
           get { return (IdentidadPersonalizado) Identity; }

           set { Identity = value; }
       }

       public PrincipalPersonalizado(IdentidadPersonalizado identity)
       {
           Identity = identity;
       }

    }
}
