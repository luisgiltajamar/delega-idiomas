using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using MvcCompleto.Models;

namespace MvcCompleto.Seguridad
{
   public   class UsuarioMembership:MembershipUser
    {
       public String Login { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Rol { get; set; }
        public int IdUsuario { get; set; }

        public UsuarioMembership(Usuarios us)
        {
            Nombre = us.nombre;
            Apellidos = us.apellidos;
            IdUsuario = us.Id;
            Rol = us.rol;
            Login = us.email;

        }

    }
}
