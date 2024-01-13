using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitTests.Services;

namespace UnitTests.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly ISampleService _sampleService;

        public SampleController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _sampleService.ProcessSampleData(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return NotFound(result);
        }
    }
}
