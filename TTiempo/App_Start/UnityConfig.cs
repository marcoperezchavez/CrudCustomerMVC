using System.Web.Mvc;
using TTiempo.Repositories;
using TTiempo.Repositories.Interfaces;
using Unity;
using Unity.Mvc5;

namespace TTiempo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<ICustomerRepository, CustomerRepository>();
        }
    }
}