using System.Web.Mvc;

namespace Passengers.Controllers
{
	public class ErrorController : Controller
	{
		public ActionResult NotFound()
		{
			return View();
		}

		public ActionResult ServerError()
		{
			return View();
		}
	}
}