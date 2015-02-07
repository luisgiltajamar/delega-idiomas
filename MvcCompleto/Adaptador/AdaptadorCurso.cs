using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcCompleto.Models;
using MvcCompleto.Models.ViewModel;

namespace MvcCompleto.Adaptador
{
   public class AdaptadorCurso:AdaptadorBase<Curso,CursoViewModel>
   {
       public override Curso ToModel(CursoViewModel view)
       {
           var model = new Curso()
           {
               idCurso = view.idCurso,
               fechaInicio = view.fechaInicio,
               nombre = view.nombre

           };
           return model;
       }
       public override CursoViewModel ToView(Curso model)
       {
           var view = new CursoViewModel()
           {
               idCurso = model.idCurso,
               fechaInicio = model.fechaInicio,
               nombre = model.nombre

           };
           return view;
       }
   }
}
