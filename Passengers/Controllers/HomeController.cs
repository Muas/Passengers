using System;
using System.Web.Mvc;
using AutoMapper;
using Passengers.Data.Repositories;
using Passengers.Extensions;
using Passengers.Models;
using Passengers.Validators;

namespace Passengers.Controllers
{
	[RoutePrefix("railway")]
	public class HomeController : Controller
	{
		private readonly IModelValidator<Passenger> _passengerValidator;
		private readonly IRepository<Data.Passenger> _repository;
		private readonly IMapper _mapper;

		public HomeController(IModelValidator<Passenger> passengerValidator, IRepository<Data.Passenger> repository, IMapper mapper)
		{
			_passengerValidator = passengerValidator;
			_repository = repository;
			_mapper = mapper;

			InitializeRepository();
		}

		private static bool _isInitialized;

		private void InitializeRepository()
		{
			if (_isInitialized) return;

			_isInitialized = true;
			_repository.Create(new Data.Passenger
			{
				Name = "Иван",
				BirthDate = new DateTime(1965, 8, 16),
				PassengerType = PassengerType.Adult.ToString()
			});
			_repository.Create(new Data.Passenger
			{
				Name = "Василиса",
				BirthDate = new DateTime(2007, 12, 28),
				PassengerType = PassengerType.Child.ToString()
			});
		}

		[Route("passengers", Name = "passengers")]
		public ActionResult Index()
		{
			var passengers = _repository.Get(filter: null)
				.MapAll<Passenger>(_mapper);
			return View(passengers);
		}

		[HttpPost]
		[Route("info/save", Name = "save")]
		public ActionResult Save(Passenger model, int? id = null)
		{
			var errors = _passengerValidator.Validate(model);
			foreach (var error in errors)
			{
				ModelState.AddModelError(error.Key, error.Value);
			}
			if (!ModelState.IsValid)
			{
				return View("Create", model);
			}
			if ((id ?? model.Id) == 0)
			{
				_repository.Create(_mapper.Map<Data.Passenger>(model));
			}
			else
			{
				var entity = _repository.Update(model.Id, _mapper.Map<Data.Passenger>(model));
				if (entity == null)
					return HttpNotFound();
			}

			return RedirectToRoute("passengers");
		}

		[HttpGet]
		[Route("info", Name = "editPassenger")]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return View(new Passenger());
			}

			var entity = _repository.Get(id.Value);
			if (entity == null)
				return HttpNotFound();
			return View(_mapper.Map<Passenger>(entity));
		}
	}
}