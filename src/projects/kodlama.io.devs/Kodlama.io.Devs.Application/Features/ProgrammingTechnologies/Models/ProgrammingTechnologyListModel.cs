using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.DTOs;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models
{
    public class ProgrammingTechnologyListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologyListDTO> Items { get; set; }
    }
}
