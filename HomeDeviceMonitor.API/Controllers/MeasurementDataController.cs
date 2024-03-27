using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDeviceMonitor.API.Controllers
{
    [Route("api/v1/Devices/{deviceId}/[controller]")]
    [ApiController]
    public class MeasurementDataController : ControllerBase
    {
        // GET: api/<MeasurementDataController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IEnumerable<string> Get(int deviceId)
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<MeasurementDataController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Post(int deviceId, [FromBody] string value)
        {
        }
    }
}
