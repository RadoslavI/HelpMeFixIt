using HelpMeFixIt.Data;
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
	}
}
