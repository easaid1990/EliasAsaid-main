using Medfar.Interview.Types;

namespace Medfar.Interview.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<int> InsertAsync(User u);
        Task<int> UpdateAsync(User u);
    }
}
