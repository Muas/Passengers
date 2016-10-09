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
		[Display(Name = @"Имя")]
		public string Name { get; set; }
		[Required]
		[Display(Name = @"Тип пассажира")]
		public PassengerType PassengerType { get; set; }
		[Required]
		[Display(Name = @"Дата рождения")]
//		[DataType(DataType.Date)]
		[UIHint("DateTime")]
//		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime BirthDate { get; set; } 
	}
}