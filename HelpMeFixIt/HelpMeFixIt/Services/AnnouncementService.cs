using HelpMeFixIt.Data.Common;
using HelpMeFixIt.Data.Entities;
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
