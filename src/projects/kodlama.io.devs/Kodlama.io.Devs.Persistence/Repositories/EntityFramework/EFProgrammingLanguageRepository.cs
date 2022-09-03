using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories.EntityFramework;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Persistence.Repositories.EntityFramework
{
    public class EFProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, BaseDbContext>, IProgrammingLanguageRepository
    {
        public EFProgrammingLanguageRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
