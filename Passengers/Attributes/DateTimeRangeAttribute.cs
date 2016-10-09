using System;
using System.ComponentModel.DataAnnotations;

namespace Passengers.Attributes
{
	public class DateTimeRangeAttribute : ValidationAttribute
	{
		private DateTime MinDateTime { get;  set; }
		private DateTime MaxDateTime { get;  set; }

		public DateTimeRangeAttribute(string minDateTime)
		{
			DateTime dateTime;
			if (!DateTime.TryParse(minDateTime, out dateTime)) throw new FormatException("minDateTime");

			MinDateTime = dateTime;
			MaxDateTime = DateTime.UtcNow;
			ErrorMessage = string.Format("Дата должна быть больше {0} и меньше {1}", MinDateTime.ToString("dd.MM.yyyy"), MaxDateTime.ToString("dd.MM.yyyy"));
		}

		public override bool IsValid(object value)
		{
			if (value == null) return true;

			DateTime dateTime;
			if (DateTime.TryParse(value.ToString(), out dateTime))
			{
				return dateTime >= MinDateTime && dateTime <= MaxDateTime;
			}
			throw new Exception();
		}
	}
}