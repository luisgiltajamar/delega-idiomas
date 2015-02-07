using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MvcCompleto.Models
{
    public class IdiomasSitio
    {
        public static List<Idioma> Idiomas=new List<Idioma>()
        {
            new Idioma(){Nombre = "Castellano",Valor = "es"},
            new Idioma(){Nombre = "Frances",Valor = "fr"},
            new Idioma(){Nombre = "Ingles",Valor = "en"},

        };

        public static void SetIdioma(String valor)
        {
            if (Idiomas.Any(o => o.Valor == valor))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(valor);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(valor);

                HttpCookie coc=new HttpCookie("lang",valor);
                coc.Expires = DateTime.Now.AddDays(7);
                HttpContext.Current.Response.Cookies.Add(coc);
            }
        }
    }

    public class Idioma
    {
       public String Valor { get; set; }
       public String Nombre { get; set; }

    }
}
