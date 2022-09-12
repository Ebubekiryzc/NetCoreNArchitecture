using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models
{
    public class ProgrammingTechnologyTypeListModel : BasePageableModel
    {
        public IList<ProgrammingTechnologyTypeListDTO> Items { get; set; }
    }
}
