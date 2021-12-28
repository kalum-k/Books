using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _userContext;
        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }
        public async Task<UserModel> Create(UserModel user)
        {
            _userContext.User.Add(user);
            await _userContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            var UserToDelete = await _userContext.User.FindAsync(id);
            _userContext.User.Remove(UserToDelete);
            await _userContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _userContext.User.ToListAsync();
        }

        public async Task<UserModel> Get(int id)
        {
            return await _userContext.User.FindAsync(id);
        }

        public async Task Update(UserModel user)
        {
            _userContext.Entry(user).State = EntityState.Modified;
            await _userContext.SaveChangesAsync();
        }
    }
}
