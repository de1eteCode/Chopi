using System.Threading.Tasks;

namespace Chopi.Modules.EFCore.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete();
        Task<int> CompleteAsync();
    }
}
