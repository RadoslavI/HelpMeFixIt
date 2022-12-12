using HelpMeFixIt.Data.Common;
using HelpMeFixIt.Data.Entities;
using HelpMeFixIt.Models;
using HelpMeFixIt.Models.Announcements;
using HelpMeFixIt.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpMeFixIt.Services
{
    public class AnnouncementService : IAnnouncementsService
    {
        private readonly IRepository repo;

        public AnnouncementService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<AnnouncementQueryServiceModel> All(
            string category = null,
            string searchTerm = null,
            AnnouncementSorting sorting = AnnouncementSorting.Newest,
            int currentPage = 1, int announcementsPerPage = 1)
        {
            var announcementQuery = repo.All<Announcement>();

            if (!string.IsNullOrWhiteSpace(category))
            {
                announcementQuery = repo.All<Announcement>()
                    .Where(a => a.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                announcementQuery = repo.All<Announcement>()
                    .Where(a => 
                    a.Title.ToLower().Contains(searchTerm.ToLower()) ||
                    a.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            announcementQuery = sorting switch
            {
                AnnouncementSorting.Payment => announcementQuery
                    .OrderBy(a => a.Payment),
                AnnouncementSorting.NotFixedFirst => announcementQuery
                    .OrderBy(a => a.FixerId != null)
                    .ThenByDescending(a => a.Id),
                _ => announcementQuery.OrderByDescending(a => a.Id)
            };

            var announcements = await announcementQuery
                .Skip((currentPage - 1) * announcementsPerPage)
                .Take(announcementsPerPage)
                .Select(a => new AnnouncementServiceModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    IsFixed = a.FixerId != null,
                    Payment = a.Payment,
                    Announcer = a.User.Email
                })
                .ToListAsync();

            var totalAnnouncements = announcementQuery.Count();

            return new AnnouncementQueryServiceModel()
            {
                Announcements = announcements,
                TotalAnnouncements = totalAnnouncements
            };
        }

        public async Task<IEnumerable<AnnouncementCategoryServiceModel>> AllCategories()
        {
            return await 
                repo
                .All<Category>()
                .Select(c => new AnnouncementCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.
                All<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo
                .All<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> Create(string title, string description, 
            decimal payment, int categoryId, string userId)
        {
            var announcement = new Announcement() 
            { 
                Title = title,
                Description = description,
                Payment = payment,
                CategoryId = categoryId,
                UserId = userId
            };

            await repo.AddAsync(announcement);
            await repo.SaveChangesAsync();

            return announcement.Id;
        }
    }
}
