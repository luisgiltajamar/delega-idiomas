using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcCompleto.Models;
using MvcCompleto.Models.ViewModel;

namespace MvcCompleto.Adaptador
{
    public class AdaptadorImagen:AdaptadorBase<Imagen,ImagenViewModel>
    {
        public override Imagen ToModel(ImagenViewModel view)
        {
            var model = new Imagen()
            {
                id = view.id,
                idCurso = view.idCurso,
                url = view.url
            };
            return model;
        }
        public override ImagenViewModel ToView(Imagen model)
        {
            var view = new ImagenViewModel()
            {
                id = model.id,
                idCurso = model.idCurso,
                url = model.url,
                Curso = model.Curso.nombre
            };
            return view;
        }
    }
}
