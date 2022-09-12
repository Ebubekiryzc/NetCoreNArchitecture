using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.CreateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.DeleteProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.DTOs;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Queries.GetByIdProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Queries.GetListProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Queries.GetListProgrammingTechnologyTypeByDynamic;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologyTypesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingTechnologyTypeCommand createProgrammingTechnologyTypeCommand)
        {
            CreatedProgrammingTechnologyTypeDTO result = await Mediator.Send(createProgrammingTechnologyTypeCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingTechnologyTypeCommand updateProgrammingTechnologyTypeCommand)
        {
            UpdatedProgrammingTechnologyTypeDTO result = await Mediator.Send(updateProgrammingTechnologyTypeCommand);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingTechnologyTypeCommand deleteProgrammingTechnologyTypeCommand)
        {
            DeletedProgrammingTechnologyTypeDTO result = await Mediator.Send(deleteProgrammingTechnologyTypeCommand);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingTechnologyTypeQuery getByIdProgrammingTechnologyTypeQuery)
        {
            ProgrammingTechnologyTypeGetByIdDTO result = await Mediator.Send(getByIdProgrammingTechnologyTypeQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologyTypeQuery getListProgrammingTechnologyTypeQuery = new() { PageRequestInstance = pageRequest };
            ProgrammingTechnologyTypeListModel result = await Mediator.Send(getListProgrammingTechnologyTypeQuery);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamicQuery)
        {
            GetListProgrammingTechnologyTypeByDynamicQuery getListProgrammingTechnologyTypeByDynamicQuery = new() { PageRequestInstance = pageRequest, Dynamic = dynamicQuery };
            ProgrammingTechnologyTypeListModel result = await Mediator.Send(getListProgrammingTechnologyTypeByDynamicQuery);
            return Ok(result);
        }
    }
}
