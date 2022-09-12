using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs;

namespace Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Models
{
    public class UserProfileSocialPlatformListModel : BasePageableModel
    {
        public IList<UserProfileSocialPlatformListDTO> Items { get; set; }
    }
}
