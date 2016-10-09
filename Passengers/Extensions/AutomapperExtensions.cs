using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Passengers.Extensions
{
	public static class AutomapperExtensions
	{
		public static IEnumerable<T> MapAll<T>(this IEnumerable source, IMapper mapper)
		{
			foreach (var item in source)
			{
				yield return mapper.Map<T>(item);
			}
		}
	}
}