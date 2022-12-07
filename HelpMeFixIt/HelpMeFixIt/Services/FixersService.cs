using HelpMeFixIt.Data;
using HelpMeFixIt.Data.Common;
using HelpMeFixIt.Data.Entities;
using HelpMeFixIt.Models.Fixers;
using HelpMeFixIt.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HelpMeFixIt.Services
{
	public class FixersService : IFixersService
	{
		private readonly IRepository repo;

		public FixersService(IRepository _repo)
		{
			this.repo = _repo;
		}

        public async Task Create(string userId, string phoneNumber)
        {
			var fixer = new Fixer()
			{
				fixesCount = 0,
				UserId = userId,
				PhoneNumber = phoneNumber
			};

			await repo.AddAsync(fixer);
			await repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
			return await repo.All<Fixer>()
				.AnyAsync(f => f.UserId == userId);
        }

        public async Task<IEnumerable<FixersIndexServiceModel>> TopThreeFixers()
		{
			return await 
				repo.All<Fixer>()
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

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await repo.All<Fixer>().AnyAsync(f => f.PhoneNumber == phoneNumber);
        }
    }
}
