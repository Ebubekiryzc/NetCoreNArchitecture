using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Services.Repositories.EntityFramework
{
    public interface IProgrammingLanguageRepository : IRepository<ProgrammingLanguage>, IAsyncRepository<ProgrammingLanguage>
    {
    }
}
