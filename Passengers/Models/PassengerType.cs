using System.ComponentModel.DataAnnotations;

namespace Passengers.Models
{
	public enum PassengerType
	{
		[Display(Name = @"Не задан")]
		None = 0,
		[Display(Name = @"Взрослый (от 10 лет)")]
		Adult,
		[Display(Name = @"Ребенок (от 5 до 10 лет)")]
		Child,
		[Display(Name = @"Младенец (до 5)")]
		Baby
	}
}