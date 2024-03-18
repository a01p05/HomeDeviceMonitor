using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDeviceMonitor.API.Controllers
{
    [Route("api/v1/Devices/{deviceId}/[controller]")]
    [ApiController]
    public class MeasurementConfigurationsController : ControllerBase
    {
        // GET: api/<MeasurementConfigurationsController>
        [HttpGet]
        public IEnumerable<string> Get(int deviceId)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MeasurementConfigurationsController>/5
        [HttpGet("{measurementConfigurationId}")]
        public string Get(int deviceId, int measurementConfigurationId)
        {
            return "value";
        }

        // POST api/<MeasurementConfigurationsController>
        [HttpPost]
        public void Post(int deviceId, [FromBody] string value)
        {
        }

        // PUT api/<MeasurementConfigurationsController>/5
        [HttpPut("{measurementConfigurationId}")]
        public void Put(int deviceId, int measurementConfigurationId, [FromBody] string value)
        {
        }

        // DELETE api/<MeasurementConfigurationsController>/5
        [HttpDelete("{measurementConfigurationId}")]
        public void Delete(int deviceId, int measurementConfigurationId)
        {
        }
    }
}
