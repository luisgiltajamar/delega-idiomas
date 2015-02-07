using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using MvcCompleto.Adaptador;
using MvcCompleto.Models;
using MvcCompleto.Models.ViewModel;
using MvcCompleto.Repositorio;

namespace MvcCompleto.Controllers
{

    [Authorize]
    public class AlumnosController : Controller
    {

        private IRepositorio<Alumno> repo;
        private IAdaptador<Alumno, AlumnoViewModel> adaptador;


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.Cookies["lang"] != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Request.Cookies["lang"].Value);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Request.Cookies["lang"].Value);
            }


            base.OnActionExecuting(filterContext);



        }

        public AlumnosController(IRepositorio<Alumno> repo,
            IAdaptador<Alumno, AlumnoViewModel> adaptador
            )
        {
            this.repo = repo;
            this.adaptador = adaptador;
        }

        // GET: Alumnos
        [AllowAnonymous]
        public ActionResult Index()
        {
            var data = repo.Get();
            var final = adaptador.ToView(data);


            return View(final);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Alta()
        {

            var data = DependencyResolver.Current.
                GetService<IRepositorio<Curso>>().Get();

            var dataView = DependencyResolver.Current.
                GetService<IAdaptador <Curso,CursoViewModel>>()
                .ToView(data);

            ViewBag.idCurso = 
                new SelectList(dataView, "idCurso", "nombre");

            return View(new AlumnoViewModel());
        }
        [HttpPost]
        public ActionResult Alta(AlumnoViewModel alumno)
        {
            var data = adaptador.ToModel(alumno);
            if (ModelState.IsValid)
            {
                repo.Add(data);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Correo()
        {
            return View(new EnvioCorreo());
        }
        [HttpPost]
        public ActionResult Correo(EnvioCorreo model)
        {
            var mens = new MailMessage();
            mens.To.Add(model.Destino);
            mens.From=new MailAddress("ftajamar2@tajamar365.com");
            mens.Subject = model.Asunto;

            @ViewBag.mensaje = model.Mensaje;
            @ViewBag.persona = "Luis";

            mens.Body =ObtenerPartial("_PlantillaCorreo");
            mens.IsBodyHtml = true;
            mens.CC.Add("lamaslg@gmail.com");
           // mens.Attachments.Add(new Attachment());

            var cl = new SmtpClient();
           

            try
            {
                cl.Send(mens);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index");
        }

        public string ObtenerPartial(String nombre)
        {
            using (var sw=new StringWriter())
            {
                var vista = ViewEngines.Engines.FindPartialView(ControllerContext, nombre);
                var contexto = new ViewContext(ControllerContext, vista.View, ViewData, TempData, sw);
                vista.View.Render(contexto,sw);
                vista.ViewEngine.ReleaseView(ControllerContext,vista.View);
                return sw.GetStringBuilder().ToString();

            }


        }

        [HttpPost]
        public ActionResult Idioma(string id)
        {
            IdiomasSitio.SetIdioma(id);
            return Json("OK");
        }
    }
}