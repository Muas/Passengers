using System;
using System.Reflection;

namespace Passengers.Extensions
{
	public static class EnumExtensions
	{
		public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
		{
			if (value == null) throw new ArgumentNullException("value");

			return value.GetType().GetField(Enum.GetName(value.GetType(), value)).GetCustomAttribute<TAttribute>();
		}
	}
}