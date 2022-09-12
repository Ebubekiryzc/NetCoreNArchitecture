using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories.EntityFramework
{
    public class EFUserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public EFUserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
