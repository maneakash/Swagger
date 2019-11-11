using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(CustomConventions))] // api convention type at controller type
    [ApiExplorerSettings(GroupName = "SampleOpenApiSpecification")]
    public class NonCustomConventionsTestController : ControllerBase
    {
        // GET: api/NonCustomConventionsTest
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/NonCustomConventionsTest/5
        [HttpGet("{id}", Name = "NonCustomConventions_Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NonCustomConventionsTest
        [HttpPost]
        //[ApiConventionMethod(typeof(CustomConventions), nameof(CustomConventions.MethodPrefix_Goes_here))]
        public void MethodPrefix_Goes_here_Post([FromBody] string value)
        {
        }

        // PUT: api/NonCustomConventionsTest/5
        [HttpPut("{id}")]
        //[ApiConventionMethod(typeof(CustomConventions), nameof(CustomConventions.MethodPrefix_Goes_here))]
        public void test_put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
