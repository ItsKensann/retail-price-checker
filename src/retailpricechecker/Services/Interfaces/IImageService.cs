namespace retailpricechecker.Services.Interfaces
{
    public interface IImageService
    {
        Task<string?> GetProductImageString(string materialNumber);
    }
}
