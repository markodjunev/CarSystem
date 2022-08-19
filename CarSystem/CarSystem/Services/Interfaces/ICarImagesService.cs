namespace CarSystem.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface ICarImagesService
    {
        Task CreateAsync(int carId, int imageId);
    }
}
