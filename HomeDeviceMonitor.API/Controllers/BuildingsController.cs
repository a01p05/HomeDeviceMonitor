using HomeDeviceMonitor.API.Controllers;
using HomeDeviceMonitor.Application.Entities.Buildings.Commands.Create;
using HomeDeviceMonitor.Application.Entities.Buildings.Queries.GetDetail;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeHouseMonitor.API.Controllers
{
    /// <summary>
    /// Buildings - the place where the Buildings are located
    /// </summary>
    /// <returns></returns>
    [Route("api/buildings")]
    public class BuildingsController : BaseController
    {
        // GET: api/<BuildingsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BuildingsController>/5
        [HttpGet("{buildingId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<BuildingDetailVm>> Get(int buildingId)
        {
            var vm = await Mediator.Send(new GetBuildingDetailQuery() { BuildingId = buildingId });
            return vm;
        }

        // POST api/<BuildingsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateBuildingCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<BuildingsController>/5
        [HttpPut("{buildingId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Put(int buildingId, [FromBody] string value)
        {
        }

        [HttpPatch("{buildingId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Patch(int buildingId, [FromBody] string value)
        {
        }

        // DELETE api/<BuildingsController>/5
        [HttpDelete("{buildingId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int buildingId)
        {
        }
    }
}
