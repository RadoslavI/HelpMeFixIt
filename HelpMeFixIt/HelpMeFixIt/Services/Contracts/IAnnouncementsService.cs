using HelpMeFixIt.Models.Announcements;

namespace HelpMeFixIt.Services.Contracts
{
    public interface IAnnouncementsService
    {
        Task<IEnumerable<AnnouncementCategoryServiceModel>> AllCategories();
        Task<bool> CategoryExists(int categoryId);
        Task<int> Create(string title, string description,
            decimal payment, int categoryId, string userId);
    }
}
