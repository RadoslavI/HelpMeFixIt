using HelpMeFixIt.Data.Common;
using HelpMeFixIt.Infrastructure;
using HelpMeFixIt.Models.Announcements;
using HelpMeFixIt.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpMeFixIt.Controllers
{
	[Authorize]
    public class AnnouncementsController : Controller
    {
		private readonly IAnnouncementsService announcements;

        public AnnouncementsController(
			IAnnouncementsService _announcements)
        {
            this.announcements = _announcements;
        }

        [AllowAnonymous]
		public async Task<IActionResult> All()
        {
            return View(new AllAnnouncementsQueryModel());
        }

		public async Task<IActionResult> Mine()
		{
			return View(new AllAnnouncementsQueryModel());
		}

		public async Task<IActionResult> Details(int id)
		{
			return View(new AnnouncementsDetailsViewModel());
		}

		[HttpGet]
		public async Task<IActionResult> Add() 
		{
			return View(new AnnouncementFormModel()
			{
				Categories = await announcements.AllCategories()
			});
		}

		[HttpPost]
		public async Task<IActionResult> Add(AnnouncementFormModel model)
		{
			if (!await announcements.CategoryExists(model.CategoryId))
			{
				this.ModelState.AddModelError(nameof(model.CategoryId),
					"Category does not exist.");
			}

			if (!ModelState.IsValid)
			{
				model.Categories = await announcements.AllCategories();

				return View(model);
			}

			string userId = this.User.Id();

			var newAnnouncementId = await announcements.Create(model.Title,
				model.Description, model.Payment,
				model.CategoryId, userId);

			return RedirectToAction(nameof(Details), new { id = newAnnouncementId });
		}

		[HttpGet]
		public async Task<IActionResult> Edit()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, AnnouncementFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
		}

		[HttpGet]
		public async Task<IActionResult> Delete()
		{
			return View(new AnnouncementsDetailsViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int id, AnnouncementFormModel model)
		{
			return RedirectToAction(nameof(All));
		}

		[HttpPost]
		public async Task<IActionResult> Fix(int id)
		{
			return RedirectToAction(nameof(Mine));
		}

		[HttpPost]
		public async Task<IActionResult> Unfix(int id)
		{
			return RedirectToAction(nameof(Mine));
		}
	}
}
