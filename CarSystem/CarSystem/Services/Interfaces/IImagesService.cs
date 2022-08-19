using System.Threading.Tasks;

namespace CarSystem.Services.Interfaces
{
    public interface IImagesService
    {
        Task<int> CreateAsync(string originalPath);
    }
}
