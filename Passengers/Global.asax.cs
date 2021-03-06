﻿using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Passengers.Mappings;
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

			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

			container.Register(typeof (IModelValidator<>), new[] {Assembly.GetExecutingAssembly()}, Lifestyle.Singleton);

			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<PassengerProfile>();
			});
			container.Register(() => config.CreateMapper());

			Common.Configuration.RegisterDependencies(container);
			Data.Configuration.RegisterDependencies(container);

			container.Verify();
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
		}
	}
}
