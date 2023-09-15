using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        // GET: api/<DashboardsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "dashboard 1", "dashboard 2" };
        }

        // GET api/<DashboardsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"value {id}";
        }

        // POST api/<DashboardsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DashboardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DashboardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
