using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelpMeFixIt.Controllers
{
	public class CommentController : Controller
	{
		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Create(CommentInputModel commentInputModel)
		{
			if (!this.ModelState.IsValid)
			{
				return this.Redirect("/");
			}

			await this.commentService.CreateAsync(commentInputModel);

			return this.RedirectToAction("GetDetails", "Announcements", new { id = commentInputModel.AnnouncementId });
		}

		[Authorize]
		public async Task<IActionResult> Delete(int commentId)
		{
			var currentUrl = this.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "Referer").Value;
			var announcementId = await this.commentService.DeleteAsync(commentId);
			return this.Redirect(currentUrl);
		}
	}
}
