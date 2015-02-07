using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MvcCompleto.Models.ViewModel
{
   public class AlumnoViewModel
    {
        public int idAlumno { get; set; }
       [Display(ResourceType=typeof(Resource),Name = "frmNom")]
       [Required(ErrorMessage = "El nombre es obligatorio")]
        public string nombre { get; set; }
       [DisplayName("Edad")]
       public Nullable<int> edad { get; set; }
       [DisplayName("Curso")]
       [Required(ErrorMessage = "El curso es obligatorio")]
       public int idCurso { get; set; }

       public CursoViewModel Curso { get; set; }


    }
}
