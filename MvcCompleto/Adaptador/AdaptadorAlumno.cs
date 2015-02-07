using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcCompleto.Models;
using MvcCompleto.Models.ViewModel;

namespace MvcCompleto.Adaptador
{
    public class AdaptadorAlumno:
        AdaptadorBase<Alumno,AlumnoViewModel>

    {
        public override Alumno ToModel(AlumnoViewModel view)
        {
            var model = new Alumno()
            {
                edad = view.edad,
                idAlumno = view.idAlumno,
                nombre = view.nombre,
                idCurso = view.idCurso,
            };
            return model;
        }

        public override AlumnoViewModel ToView(Alumno model)
        {
            var view = new AlumnoViewModel()
            {
                edad = model.edad,
                idAlumno = model.idAlumno,
                nombre = model.nombre,
                idCurso = model.idCurso,
                Curso = new CursoViewModel()
                {
                    nombre = model.Curso.nombre,
                    fechaInicio = model.Curso.fechaInicio,
                     idCurso = model.Curso.idCurso

                }
            };
            return view;
        }
    }
}
