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
		private readonly IFixersService fixers;

		public AnnouncementsController(
			IAnnouncementsService _announcements,
			IFixersService _fixers)
        {
            this.announcements = _announcements;
            this.fixers = _fixers;
		}

        [AllowAnonymous]
		public async Task<IActionResult> All([FromQuery] AllAnnouncementsQueryModel query)
        {
			var queryResult = await announcements.All(
				query.Category,
				query.SearchTerm,
				query.Sorting,
				query.CurrentPage,
				AllAnnouncementsQueryModel.AnnouncementsPerPage);

			query.TotalAnnouncementsCount = queryResult.TotalAnnouncements;
			query.Announcements = queryResult.Announcements;

			var announcementCategories = await announcements.AllCategoriesNames();
			query.Categories = announcementCategories;

			return View(query);
        }

		public async Task<IActionResult> Mine()
		{
			IEnumerable<AnnouncementServiceModel> myAnnouncements = null;

			var userId = this.User.Id();

			myAnnouncements = await announcements
				.AllAnnouncementsByUserId(userId);

			return View(myAnnouncements);
		}

        public async Task<IActionResult> MyFixes()
        {
			IEnumerable<AnnouncementServiceModel> myFixes = null;

			var userId = this.User.Id();

			if (!await fixers.ExistsById(userId))
			{
				return BadRequest();
			}

			var currentFixerId = await fixers.GetFixerId(userId);

			myFixes = await announcements
				.AllAnnouncementsByFixerId(currentFixerId);

			return View(myFixes);
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
