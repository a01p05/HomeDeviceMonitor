﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HomeDeviceMonitor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PVmonitorDataController : ControllerBase
    {
        // GET: api/<PVmonitorDataController>
        [HttpGet("pvmonitorIp")]
        public IEnumerable<string> Get(string pvmonitorIp)
        {
            return new string[] { "value1", "value2" };
        }
    }
}
