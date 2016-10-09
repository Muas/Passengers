using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Passengers.Models;
using Passengers.Validators;

namespace Passengers.Controllers
{
	public class HomeController : Controller
	{
		private readonly IModelValidator<Passenger> _passengerValidator;

		public HomeController(IModelValidator<Passenger> passengerValidator)
		{
			_passengerValidator = passengerValidator;
		}

		public ActionResult Index()
		{
			var passengers = new List<Passenger>() { new Passenger()
			{
				Id = 1, BirthDate = new DateTime(2000, 12, 31), PassengerType = PassengerType.Adult, Name = "Test" }
			};
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
			return RedirectToAction("Index");
		}

		public ActionResult Edit(string @class, int id)
		{
			return View(new Passenger() {Id = 1, BirthDate = new DateTime(2000, 12, 31), PassengerType = PassengerType.Adult, Name = "Test"});
		}
	}
}