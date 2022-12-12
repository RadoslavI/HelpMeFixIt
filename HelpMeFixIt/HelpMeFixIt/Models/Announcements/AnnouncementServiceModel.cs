using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HelpMeFixIt.Models.Announcements
{
    public class AnnouncementServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; } = null!;

        public string Description { get; init; } = null!;

        public string Announcer { get; init; } = null!;

        public decimal Payment { get; init; }

        [Display(Name = "Is Fixed")]
        public bool IsFixed { get; init; }
    }
}