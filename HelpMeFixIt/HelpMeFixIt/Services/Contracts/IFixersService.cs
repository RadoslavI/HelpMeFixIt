using HelpMeFixIt.Models.Fixers;

namespace HelpMeFixIt.Services.Contracts
{
    public interface IFixersService
    {
        Task<IEnumerable<FixersIndexServiceModel>> TopThreeFixers();
    }
}
