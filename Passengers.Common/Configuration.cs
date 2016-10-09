using Passengers.Common.Interfaces;
using SimpleInjector;

namespace Passengers.Common
{
	public static class Configuration
	{
		public static void RegisterDependencies(Container container)
		{
			container.Register<IDateTimeProvider, UtcDateTimeProvider>(Lifestyle.Singleton);
		}
	}
}