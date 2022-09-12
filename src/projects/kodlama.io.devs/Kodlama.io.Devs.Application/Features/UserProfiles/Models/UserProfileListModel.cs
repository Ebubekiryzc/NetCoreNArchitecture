using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfiles.DTOs;

namespace Kodlama.io.Devs.Application.Features.UserProfiles.Models
{
    public class UserProfileListModel : BasePageableModel
    {
        public IList<UserProfileListDTO> Items { get; set; }
    }
}
