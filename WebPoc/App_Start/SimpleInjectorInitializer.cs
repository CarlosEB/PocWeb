using Poc.Data.Context;

[assembly: WebActivator.PostApplicationStartMethod(typeof(WebPoc.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace WebPoc.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Poc.Domain.Interfaces;
    using Poc.Data.Repositories;
    using System.Configuration;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // Register your types, for instance:

            container.Register(() => new PocContext("PocContext"), Lifestyle.Scoped);

            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>), Lifestyle.Transient);

            container.Register<IUserRepository, UserRepository>(Lifestyle.Transient);
        }
    }
}