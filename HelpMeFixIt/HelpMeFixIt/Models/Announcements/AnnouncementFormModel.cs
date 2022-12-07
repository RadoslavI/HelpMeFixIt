using HelpMeFixIt.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static HelpMeFixIt.Data.DataConstants.Announcement;
#nullable disable

namespace HelpMeFixIt.Models.Announcements
{
	public class AnnouncementFormModel
	{
		public AnnouncementFormModel()
		{
			Categories = new HashSet<AnnouncementCategoryServiceModel>();
		}

		[Required]
		[StringLength(TitleMaxLength,
			MinimumLength = TitleMinLength)]
		public string Title { get; init; }

		[Required]
		[StringLength(DescriptionMaxLength,
			MinimumLength = DescriptionMinLength)]
		public string Description { get; init; }

		[Required]
		[Range(0.00, (double) Decimal.MaxValue)]
		public decimal Payment { get; init; }

		[Display(Name = "Category")]
		public int CategoryId { get; set; }

		public IEnumerable<AnnouncementCategoryServiceModel> Categories { get; set; }
	}
}
