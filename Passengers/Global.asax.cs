using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Passengers.Validators;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace Passengers
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var container = new Container();
			
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

			container.Register(typeof (IModelValidator<>), new[] {Assembly.GetExecutingAssembly()}, Lifestyle.Singleton);
			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			Common.Configuration.RegisterDependencies(container);
			container.Verify();

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}
	}
}
