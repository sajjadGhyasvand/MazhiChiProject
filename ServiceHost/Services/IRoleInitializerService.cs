using System.Threading.Tasks;

namespace ServiceHost.Services
{
    public interface IRoleInitializerService
    {
        Task InitializeAsync();
    }
}
