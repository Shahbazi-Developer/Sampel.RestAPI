using Microsoft.EntityFrameworkCore;
using Sampel.RestAPI.Core.Contracts.RestApiDemos.Users;
using Sampel.RestAPI.Core.Domain.RestApiDemos.Entities;
using Sampel.RestAPI.Infra.Data.Sql.Commands.Common;

namespace Sampel.RestAPI.Infra.Data.Sql.Commands.Users;

public class UserRepository : IUserRepository
{
    private readonly RestAPICommandDbContext _ctx;

    public UserRepository(RestAPICommandDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _ctx.Users.FirstOrDefaultAsync(x => x.Username == username);
    }

    public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _ctx.Users.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);
    }

    public async Task AddAsync(User user)
    {
        _ctx.Users.Add(user);
        await _ctx.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _ctx.Users.Update(user);
        await _ctx.SaveChangesAsync();
    }
}
