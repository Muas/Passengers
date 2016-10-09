using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Passengers.Models
{
	public class Passenger
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }
		[Required]
		[RegularExpression(@"^[А-Я][а-я\-]*", ErrorMessage = @"Поле Имя должно содержать только буквы русского алфавита")]
		[Display(Name = @"Имя")]
		public string Name { get; set; }
		[Required]
		[Display(Name = @"Тип пассажира")]
		public PassengerType PassengerType { get; set; }
		[Required]
		[Display(Name = @"Дата рождения")]
		[UIHint("DateTime")]
		public DateTime BirthDate { get; set; } 
	}
}