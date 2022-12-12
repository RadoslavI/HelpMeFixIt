namespace HelpMeFixIt.Models.Announcements
{
    public class AnnouncementQueryServiceModel
    {
        public AnnouncementQueryServiceModel()
        {
            Announcements = new HashSet<AnnouncementServiceModel>();
        }
        public int TotalAnnouncements { get; set; }

        public IEnumerable<AnnouncementServiceModel> Announcements { get; set; }
    }
}
