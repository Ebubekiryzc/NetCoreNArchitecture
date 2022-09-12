using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.CreateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.DeleteUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Commands.UpdateUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.DTOs;
using Kodlama.io.Devs.Application.Features.UserProfiles.Models;
using Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetByIdUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListUserProfile;
using Kodlama.io.Devs.Application.Features.UserProfiles.Queries.GetListUserProfileByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserProfileCommand createUserProfileCommand)
        {
            CreatedUserProfileDTO result = await Mediator.Send(createUserProfileCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserProfileCommand updateUserProfileCommand)
        {
            UpdatedUserProfileDTO result = await Mediator.Send(updateUserProfileCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserProfileCommand deleteUserProfileCommand)
        {
            DeletedUserProfileDTO result = await Mediator.Send(deleteUserProfileCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserProfileQuery getByIdUserProfileQuery)
        {
            UserProfileGetByIdDTO result = await Mediator.Send(getByIdUserProfileQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListUserProfileQuery getListUserProfileQuery = new() { PageRequestInstance = pageRequest };
            UserProfileListModel result = await Mediator.Send(getListUserProfileQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamicQuery)
        {
            GetListUserProfileByDynamicQuery getListUserProfileByDynamicQuery = new() { PageRequestInstance = pageRequest, Dynamic = dynamicQuery };
            UserProfileListModel result = await Mediator.Send(getListUserProfileByDynamicQuery);
            return Ok(result);
        }
    }
}
