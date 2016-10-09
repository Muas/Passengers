using System.Reflection;
using Passengers.Data.Repositories;
using SimpleInjector;

namespace Passengers.Data
{
	public static class Configuration
	{
		public static void RegisterDependencies(Container container)
		{
			container.Register(typeof (IRepository<>), typeof(InMemoryRepository<>), Lifestyle.Singleton);
		}  
	}
}