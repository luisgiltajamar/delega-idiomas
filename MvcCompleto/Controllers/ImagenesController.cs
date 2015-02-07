using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCompleto.Adaptador;
using MvcCompleto.Models;
using MvcCompleto.Models.ViewModel;
using MvcCompleto.Repositorio;

namespace MvcCompleto.Controllers
{
    public class ImagenesController : Controller
    {
        private IRepositorio<Imagen> repositorio;
        private IAdaptador<Imagen, ImagenViewModel> adaptador;

        public ImagenesController(IRepositorio<Imagen> repositorio,
            IAdaptador<Imagen, ImagenViewModel> adaptador
            )
        {
            this.repositorio = repositorio;
            this.adaptador = adaptador;
        }

        // GET: Imagenes
        public ActionResult Index(int id)
        {
            Session["idCurso"] = id;
            var data = repositorio.Get(o => o.idCurso == id);
            var dataView = adaptador.ToView(data);
            return View(dataView);
        }

        public ActionResult Create()
        {
            return View(new ImagenViewModel());
        }

        [HttpPost]
        public ActionResult Create(ImagenViewModel modelo,HttpPostedFileBase[] imagenes)
        {

            foreach (var imagen in imagenes)
            {
                if (imagen != null && imagen.ContentLength > 0)
                {
                    var url = Server.MapPath("~/uploads/" + imagen.FileName);
                    modelo.url = "/uploads/" + imagen.FileName;
                    modelo.idCurso = (int)Session["idCurso"];
                    var d = adaptador.ToModel(modelo);
                    repositorio.Add(d);

                    imagen.SaveAs(url);
                }
            }
            return RedirectToAction("Index", new { id = Session["idCurso"] });
        }

    }
}