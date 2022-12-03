namespace HelpMeFixIt.Infrastructure
{
    public interface IUnitOfWork
    {
        void UploadImage(IFormFile file);
    }
}
