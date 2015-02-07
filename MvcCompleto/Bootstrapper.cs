using System.Data.Entity;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MvcCompleto.Adaptador;
using MvcCompleto.Models;
using MvcCompleto.Models.ViewModel;
using MvcCompleto.Repositorio;
using Unity.Mvc4;

namespace MvcCompleto
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {

        container.RegisterType<DbContext, DelegaEntities>();

        container.RegisterType<IRepositorio<Alumno>, 
            RepositorioEntity<Alumno>>();
        container.RegisterType<IRepositorio<Curso>,
            RepositorioEntity<Curso>>();
        container.RegisterType<IRepositorio<Profesor>,
            RepositorioEntity<Profesor>>();
        container.RegisterType<IRepositorio<Imagen>,
            RepositorioEntity<Imagen>>();


        container.RegisterType<IAdaptador<Alumno,AlumnoViewModel>,
            AdaptadorAlumno>();
        container.RegisterType<IAdaptador<Curso, CursoViewModel>,
           AdaptadorCurso>();
        container.RegisterType<IAdaptador<Imagen, ImagenViewModel>,
          AdaptadorImagen>();

    }
  }
}