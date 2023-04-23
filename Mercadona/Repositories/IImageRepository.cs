namespace Mercadona_V2.Repositories
{
    public interface IImageRepository
    {

        Task<string> UploadAsync(IFormFile file);

    }
}
