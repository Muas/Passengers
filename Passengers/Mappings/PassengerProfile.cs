using AutoMapper;
using Passengers.Models;

namespace Passengers.Mappings
{
	public class PassengerProfile : Profile
	{
		public PassengerProfile()
		{
			CreateMap<Passenger, Data.Passenger>().ReverseMap();
		}
	}
}