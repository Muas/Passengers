using System;

namespace Passengers.Data
{
	public class Passenger : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string PassengerType { get; set; }
		public DateTime	BirthDate { get; set; }
	}

	public interface IEntity
	{
		int Id { get; set; }
	}
}