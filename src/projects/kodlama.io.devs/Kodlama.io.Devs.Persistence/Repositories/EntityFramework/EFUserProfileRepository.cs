using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories.EntityFramework
{
    public class EFUserProfileRepository : EfRepositoryBase<UserProfile, BaseDbContext>, IUserProfileRepository
    {
        public EFUserProfileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
