using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Genders.DTOs;

namespace Kodlama.io.Devs.Application.Features.Genders.Models
{
    public class GenderListModel : BasePageableModel
    {
        public IList<GenderListDTO> Items { get; set; }
    }
}
