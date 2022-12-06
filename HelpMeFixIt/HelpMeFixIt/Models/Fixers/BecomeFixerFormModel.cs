using System.ComponentModel.DataAnnotations;
using static HelpMeFixIt.Data.DataConstants.Fixer;

namespace HelpMeFixIt.Models.Fixers
{
	public class BecomeFixerFormModel
	{
		[Required]
		[StringLength(PhoneMaxLength, MinimumLength = PhoneMinLength)]
		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; init; }
	}
}
