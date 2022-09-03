using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.DTOs;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageListModel : BasePageableModel
    {
        public IList<ProgrammingLanguageListDTO> Items { get; set; }
    }
}
