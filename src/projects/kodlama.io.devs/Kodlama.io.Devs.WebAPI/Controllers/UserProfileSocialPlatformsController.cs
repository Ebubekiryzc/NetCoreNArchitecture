using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.CreateUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.DeleteUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Commands.UpdateUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Models;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Queries.GetByIdUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Queries.GetListUserProfileSocialPlatform;
using Kodlama.io.Devs.Application.Features.UserProfileSocialPlatforms.Queries.GetListUserProfileSocialPlatformByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileSocialPlatformsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserProfileSocialPlatformCommand createUserProfileSocialPlatformCommand)
        {
            CreatedUserProfileSocialPlatformDTO result = await Mediator.Send(createUserProfileSocialPlatformCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserProfileSocialPlatformCommand updateUserProfileSocialPlatformCommand)
        {
            UpdatedUserProfileSocialPlatformDTO result = await Mediator.Send(updateUserProfileSocialPlatformCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserProfileSocialPlatformCommand deleteUserProfileSocialPlatformCommand)
        {
            DeletedUserProfileSocialPlatformDTO result = await Mediator.Send(deleteUserProfileSocialPlatformCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserProfileSocialPlatformQuery getByIdUserProfileSocialPlatformQuery)
        {
            UserProfileSocialPlatformGetByIdDTO result = await Mediator.Send(getByIdUserProfileSocialPlatformQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListUserProfileSocialPlatformQuery getListUserProfileSocialPlatformQuery = new() { PageRequestInstance = pageRequest };
            UserProfileSocialPlatformListModel result = await Mediator.Send(getListUserProfileSocialPlatformQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamicQuery)
        {
            GetListUserProfileSocialPlatformByDynamicQuery getListUserProfileSocialPlatformByDynamicQuery = new() { PageRequestInstance = pageRequest, Dynamic = dynamicQuery };
            UserProfileSocialPlatformListModel result = await Mediator.Send(getListUserProfileSocialPlatformByDynamicQuery);
            return Ok(result);
        }
    }
}
