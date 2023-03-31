using MyCommerce.Model;

namespace MyCommerce.Services
{
    public interface IBaseService<T,TSearch> where TSearch : class
    {
        Task<PagedResult<T>> Get(TSearch? search=null);
        Task<T> GetById(int id);
    }
}
