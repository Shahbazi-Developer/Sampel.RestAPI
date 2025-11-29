using Sampel.RestAPI.Core.Domain.RestApiDemos.Entities;

namespace Sampel.RestAPI.Core.Contracts.RestApiDemos.Users;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByRefreshTokenAsync(string refreshToken);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
}
