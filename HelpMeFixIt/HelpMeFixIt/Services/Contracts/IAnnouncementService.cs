using HelpMeFixIt.Models.Announcements;

namespace HelpMeFixIt.Services.Contracts
{
    public interface IAnnouncementService
    {
        IEnumerable<FixersIndexServiceModel> LastFiveAnnouncements();
    }
}
