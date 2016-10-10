using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Passengers.Common.Interfaces;

namespace Passengers.Attributes
{
	public class DateTimeRangeAttribute : ValidationAttribute
	{
		private DateTime MinDateTime { get;  set; }

		public DateTimeRangeAttribute(string minDateTime)
		{
			DateTime dateTime;
			if (!DateTime.TryParse(minDateTime, out dateTime)) throw new FormatException("minDateTime");

			MinDateTime = dateTime;
		}

		public override bool IsValid(object value)
		{
			if (value == null) return true;

			DateTime dateTime;
			if (!DateTime.TryParse(value.ToString(), out dateTime))
			{
				ErrorMessage = "Неверный формат даты";
				return false;
			}

			var now = DependencyResolver.Current.GetService<IDateTimeProvider>().GetDate();
			if (dateTime >= MinDateTime && dateTime <= now)
			{
				return true;
			}
			ErrorMessage = string.Format("Дата должна быть больше {0} и меньше {1}", MinDateTime.ToString("dd.MM.yyyy"), now.ToString("dd.MM.yyyy"));
			return false;
		}
	}
}