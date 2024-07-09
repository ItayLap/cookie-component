using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Hooks.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			Response.Cookies.Append("UserName", "dfgdfgdv");
			string userName = Request.Cookies["UserName"];
			ViewBag.UserName = userName;
			return View();
		}
		[HttpPost]
		public IActionResult SetCookie(string userName)
		{
			CookieOptions options = new CookieOptions
			{
				Expires = DateTime.Now.AddMinutes(30)
			};
			
			Response.Cookies.Append("UserName", userName, options);
			ViewBag.UserName = userName;
			return View("Index");
		}

		[HttpPost]
		public IActionResult DeleteCookie()
		{
			Response.Cookies.Delete("UserName");
			ViewBag.UserName = null;
			ViewBag.Message = "Cookies were burnt";
			return View("Index");
		}
	}
}
