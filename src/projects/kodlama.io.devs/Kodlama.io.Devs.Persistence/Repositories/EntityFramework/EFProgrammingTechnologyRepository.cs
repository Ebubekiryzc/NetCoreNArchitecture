using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;

namespace Kodlama.io.Devs.Persistence.Repositories.EntityFramework
{
    public class EFProgrammingTechnologyRepository : EfRepositoryBase<ProgrammingTechnology, BaseDbContext>, IProgrammingTechnologyRepository
    {
        public EFProgrammingTechnologyRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
