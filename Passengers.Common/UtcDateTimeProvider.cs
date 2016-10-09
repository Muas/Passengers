using System;
using Passengers.Common.Interfaces;

namespace Passengers.Common
{
	internal sealed class UtcDateTimeProvider : IDateTimeProvider
	{
		public DateTime GetDate()
		{
			return DateTime.UtcNow.Date;
		}
	}
}