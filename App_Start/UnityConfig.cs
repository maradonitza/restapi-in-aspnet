using BookstoreApi.Core;
using BookstoreApi.Core.Repositories;
using BookstoreApi.Persistence;
using BookstoreApi.Persistence.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BookstoreApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.RegisterType<IBookRepository, BookRepository>();
            //container.RegisterType<IAuthorRepository, AuthorRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}