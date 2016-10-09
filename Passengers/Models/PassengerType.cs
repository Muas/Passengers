using System.ComponentModel.DataAnnotations;
using Passengers.Attributes;

namespace Passengers.Models
{
	public enum PassengerType
	{
		[Display(Name = @"Не задан")]
		None = 0,
		[Display(Name = @"Взрослый (от 10 лет)")]
		[EnumRange(10,130)]
		Adult,
		[EnumRange(5, 9)]
		[Display(Name = @"Ребенок (от 5 до 10 лет)")]
		Child,
		[EnumRange(0, 4)]
		[Display(Name = @"Младенец (до 5)")]
		Baby
	}
}