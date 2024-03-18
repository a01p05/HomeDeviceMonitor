using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDeviceMonitor.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        // GET: api/<DevicesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DevicesController>/5
        [HttpGet("{deviceId}")]
        public string Get(int deviceId)
        {
            return "value";
        }

        // POST api/<DevicesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DevicesController>/5
        [HttpPut("{deviceId}")]
        public void Put(int deviceId, [FromBody] string value)
        {
        }

        // DELETE api/<DevicesController>/5
        [HttpDelete("{deviceId}")]
        public void Delete(int deviceId)
        {
        }
    }
}
