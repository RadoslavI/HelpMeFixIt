using HelpMeFixIt.Models.Fixers;

namespace HelpMeFixIt.Services.Contracts
{
    public interface IFixersService
    {
        Task<IEnumerable<FixersIndexServiceModel>> TopThreeFixers();
        Task<bool> ExistsById(string userId);
        Task<bool> UserWithPhoneNumberExists(string phoneNumber);
        void Create(string userId, string phoneNumber);
    }
}
