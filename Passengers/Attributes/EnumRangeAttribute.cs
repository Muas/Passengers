using System;
using System.ComponentModel.DataAnnotations;

namespace Passengers.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class EnumRangeAttribute : Attribute
	{
		public int Minimum { get; private set; }
		public int Maximum { get; private set; }
		public EnumRangeAttribute(int minimum, int maximum = int.MaxValue)
		{
			Minimum = minimum;
			Maximum = maximum;
		}
	}
}