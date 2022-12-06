using HelpMeFixIt.Models.Fixers;
using Microsoft.AspNetCore.Mvc;

namespace HelpMeFixIt.Controllers
{
	public class FixerController : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Become()
		{
			//if (await agentService.ExistsById(User.Id()))
			//{
			//	TempData[MessageConstant.ErrorMessage] = "Вие вече сте Агент";

			//	return RedirectToAction("Index", "Home");
			//}

			//var model = new BecomeAgentModel();

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeFixerFormModel model)
		{
			return RedirectToAction("All", "House");
		}
	}
}
