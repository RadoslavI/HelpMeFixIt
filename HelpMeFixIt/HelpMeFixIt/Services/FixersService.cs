using HelpMeFixIt.Data;
using HelpMeFixIt.Data.Entities;
using HelpMeFixIt.Models.Fixers;
using HelpMeFixIt.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpMeFixIt.Services
{
	public class FixersService : IFixersService
	{
		private readonly HelpMeFixItDbContext data;

		public FixersService(HelpMeFixItDbContext _data)
		{
			this.data = _data;
		}

        public void Create(string userId, string phoneNumber)
        {
			var fixer = new Fixer()
			{
				fixesCount = 0,
				UserId = userId,
				PhoneNumber = phoneNumber
			};

			data.Fixers.AddAsync(fixer);
			data.SaveChangesAsync();
        }

        public Task<bool> ExistsById(string userId)
        {
			return data.Fixers.AnyAsync(f => f.UserId == userId);
        }

        public async Task<IEnumerable<FixersIndexServiceModel>> TopThreeFixers()
		{
			return await 
				this.data
				.Fixers
				.OrderByDescending(f => f.fixesCount)
				.Select(f => new FixersIndexServiceModel()
				{
					Id = f.Id,
					ImagePath = f.User.ImagePath,
					Email = f.User.Email
				})
				.Take(3)
				.ToListAsync();
		}

        public Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return data.Fixers.AnyAsync(f => f.PhoneNumber == phoneNumber);
        }
    }
}
