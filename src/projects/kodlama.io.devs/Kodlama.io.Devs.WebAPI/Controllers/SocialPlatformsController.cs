using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.CreateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.DeleteSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Commands.UpdateSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.DTOs;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Models;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Queries.GetByIdSocialPlatform;
using Kodlama.io.Devs.Application.Features.SocialPlatforms.Queries.GetListSocialPlatform;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPlatformsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialPlatformCommand createSocialPlatformCommand)
        {
            CreatedSocialPlatformDTO result = await Mediator.Send(createSocialPlatformCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialPlatformCommand updateSocialPlatformCommand)
        {
            UpdatedSocialPlatformDTO result = await Mediator.Send(updateSocialPlatformCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteSocialPlatformCommand deleteSocialPlatformCommand)
        {
            DeletedSocialPlatformDTO result = await Mediator.Send(deleteSocialPlatformCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSocialPlatformQuery getByIdSocialPlatformQuery)
        {
            SocialPlatformGetByIdDTO result = await Mediator.Send(getByIdSocialPlatformQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListSocialPlatformQuery getListSocialPlatformQuery = new() { PageRequestInstance = pageRequest };
            SocialPlatformListModel result = await Mediator.Send(getListSocialPlatformQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamicQuery)
        {
            GetListSocialPlatformByDynamicQuery getListSocialPlatformByDynamicQuery = new() { PageRequestInstance = pageRequest, Dynamic = dynamicQuery };
            SocialPlatformListModel result = await Mediator.Send(getListSocialPlatformByDynamicQuery);
            return Ok(result);
        }
    }
}
