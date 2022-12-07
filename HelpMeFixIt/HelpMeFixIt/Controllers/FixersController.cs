using HelpMeFixIt.Infrastructure;
using HelpMeFixIt.Models.Fixers;
using HelpMeFixIt.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HelpMeFixIt.Controllers
{
	public class FixersController : Controller
	{
		private readonly IFixersService fixers;

        public FixersController(IFixersService _fixers)
        {
            this.fixers = _fixers;
        }

        [HttpGet]
		public async Task<IActionResult> Become()
		{
			if (await fixers.ExistsById(User.Id()))
			{
				return BadRequest();
			}

            return View();
		}

		[HttpPost]
		public async Task<IActionResult> Become(BecomeFixerFormModel model)
		{
			var userId = User.Id();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await fixers.ExistsById(userId))
			{
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "You already are a fixer!");
            }

            if (await fixers.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber),
                    "Phone number already exists. Enter another one.");
            }


            await this.fixers.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(AnnouncementsController.All), "Announcements");
        }
	}
}
