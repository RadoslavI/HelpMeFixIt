using System.ComponentModel.DataAnnotations;

namespace HelpMeFixIt.Models.Announcements
{
    public class AllAnnouncementsQueryModel
    {
        public AllAnnouncementsQueryModel()
        {
            Announcements = new HashSet<AnnouncementServiceModel>();
        }

        public const int AnnouncementsPerPage = 3;

        public string Category { get; init; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; }

        public AnnouncementSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalAnnouncementsCount { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<AnnouncementServiceModel> Announcements { get; set; }
    }
}
