using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.Genders.Commands.CreateGender;
using Kodlama.io.Devs.Application.Features.Genders.Commands.DeleteGender;
using Kodlama.io.Devs.Application.Features.Genders.Commands.UpdateGender;
using Kodlama.io.Devs.Application.Features.Genders.DTOs;
using Kodlama.io.Devs.Application.Features.Genders.Models;
using Kodlama.io.Devs.Application.Features.Genders.Queries.GetByIdGender;
using Kodlama.io.Devs.Application.Features.Genders.Queries.GetListGender;
using Kodlama.io.Devs.Application.Features.Genders.Queries.GetListGenderByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGenderCommand createGenderCommand)
        {
            CreatedGenderDTO result = await Mediator.Send(createGenderCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGenderCommand updateGenderCommand)
        {
            UpdatedGenderDTO result = await Mediator.Send(updateGenderCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGenderCommand deleteGenderCommand)
        {
            DeletedGenderDTO result = await Mediator.Send(deleteGenderCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGenderQuery getByIdGenderQuery)
        {
            GenderGetByIdDTO result = await Mediator.Send(getByIdGenderQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListGenderQuery getListGenderQuery = new() { PageRequestInstance = pageRequest };
            GenderListModel result = await Mediator.Send(getListGenderQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamicQuery)
        {
            GetListGenderByDynamicQuery getListGenderByDynamicQuery = new() { PageRequestInstance = pageRequest, Dynamic = dynamicQuery };
            GenderListModel result = await Mediator.Send(getListGenderByDynamicQuery);
            return Ok(result);
        }
    }
}
