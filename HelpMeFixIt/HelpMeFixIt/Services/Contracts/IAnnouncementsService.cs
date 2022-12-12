using HelpMeFixIt.Models;
using HelpMeFixIt.Models.Announcements;

namespace HelpMeFixIt.Services.Contracts
{
    public interface IAnnouncementsService
    {
        Task<IEnumerable<AnnouncementCategoryServiceModel>> AllCategories();
        Task<bool> CategoryExists(int categoryId);
        Task<int> Create(string title, string description,
            decimal payment, int categoryId, string userId);
        Task<AnnouncementQueryServiceModel> All(
            string category = null,
            string searchTerm = null,
            AnnouncementSorting sorting = AnnouncementSorting.Newest,
            int currentPage = 1,
            int housePerPage = 1);
        Task<IEnumerable<string>> AllCategoriesNames();
    }
}
