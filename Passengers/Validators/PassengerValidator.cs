using System.Collections.Generic;
using Passengers.Attributes;
using Passengers.Common.Interfaces;
using Passengers.Extensions;
using Passengers.Models;

namespace Passengers.Validators
{
	public class PassengerValidator : IModelValidator<Passenger>
	{
		private readonly IDateTimeProvider _dateTime;

		public PassengerValidator(IDateTimeProvider dateTime)
		{
			_dateTime = dateTime;
		}

		public IEnumerable<KeyValuePair<string, string>> Validate(Passenger model)
		{
			if (model.PassengerType == PassengerType.None)
			{
				yield return new KeyValuePair<string, string>("PassengerType", @"Поле Тип пассажира должно быть задано");
			}
			else
			{
				var attribute = model.PassengerType.GetAttribute<EnumRangeAttribute>();
				var now = _dateTime.GetDate();
				if (model.BirthDate.AddYears(attribute.Maximum) < now || model.BirthDate.AddYears(attribute.Minimum) >= now) 
					yield return new KeyValuePair<string, string>("PassengerType", @"Выбранный тип пассажира не соответствует возрасту пассажира");
			}
		}
	}
}