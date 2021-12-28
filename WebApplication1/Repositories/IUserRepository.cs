using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserModel>> Get();
        Task<UserModel> Get(int id);
        Task<UserModel> Create(UserModel user);
        Task Update(UserModel user);
        Task Delete(int id);
    }
}
