using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories.EntityFramework
{
    public interface IUserRepository : IRepository<User>, IAsyncRepository<User>
    {
    }
}
