using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Passengers.Models;

namespace Passengers.Controllers
{
	public class HomeController : Controller
	{
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
			if (ModelState.IsValid)
			{
				return RedirectToAction("Index");
			}
			else
			{
				return View("Create", model);
			}
		}

		public ActionResult Edit(string @class, int id)
		{
			return View(new Passenger() {Id = 1, BirthDate = new DateTime(2000, 12, 31), PassengerType = PassengerType.Adult, Name = "Test"});
		}
	}
}