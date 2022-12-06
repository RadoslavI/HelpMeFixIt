using HelpMeFixIt.Models.Announcements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpMeFixIt.Controllers
{
	[Authorize]
    public class AnnouncementsController : Controller
    {
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
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(AnnouncementFormModel model)
		{
			return RedirectToAction(nameof(Details), new { id = "1" });
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
