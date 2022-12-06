namespace HelpMeFixIt.Infrastructure.Contracts
{
    public interface IUnitOfWork
    {
        void UploadImage(IFormFile file);
    }
}
