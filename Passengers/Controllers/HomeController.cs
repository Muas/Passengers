using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Passengers.Data.Repositories;
using Passengers.Extensions;
using Passengers.Models;
using Passengers.Validators;

namespace Passengers.Controllers
{
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
		}

		public ActionResult Index()
		{
			var passengers = _repository.Get(filter: null)
				.MapAll<Passenger>(_mapper);
			return View(passengers);
		}

		public ActionResult Create()
		{
			return View(new Passenger());
		}
		
		public ActionResult Save(Passenger model)
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
			if (model.Id == 0)
			{
				_repository.Create(_mapper.Map<Data.Passenger>(model));
			}
			else
			{
				var entity = _repository.Update(model.Id, _mapper.Map<Data.Passenger>(model));
				if (entity == null)
					return HttpNotFound();
			}

			return RedirectToAction("Index");
		}

		public ActionResult Edit(int id)
		{
			var entity = _repository.Get(id);
			if (entity == null)
				return HttpNotFound();
			return View(_mapper.Map<Passenger>(entity));
		}
	}
}