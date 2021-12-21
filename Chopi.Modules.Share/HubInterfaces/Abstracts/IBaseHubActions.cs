using System.Threading.Tasks;

namespace Chopi.Modules.Share.HubInterfaces.Abstracts
{
    public interface IBaseHubActions<T>
        where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
    }
}
