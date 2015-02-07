using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCompleto.Models.ViewModel
{
    public class ImagenViewModel
    {
        public int id { get; set; }
        public string url { get; set; }
        public int idCurso { get; set; }

        public String Curso { get; set; }
    }
}
