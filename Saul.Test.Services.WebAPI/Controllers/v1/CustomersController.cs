using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface.UseCases;
using Saul.Test.Transversal.Common;
using System.Threading.Tasks;

namespace Saul.Test.Services.WebAPI.Controllers.v1
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class CustomersController : Controller
    {
        private readonly ICustomersApplication _customersApplication;
        private readonly ILoggerManager _logger;

        public CustomersController(ICustomersApplication customersApplication, ILoggerManager logger)
        {
            _customersApplication = customersApplication;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customersApplication.GetAll();
            if (response.IsSuccess)
            {
                _logger.LogInfo("Test LogInfo GetAll - request processed.");
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{customerId}")]
        public async Task<IActionResult> Get(string customerId)
        {
            var response = await _customersApplication.Get(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customersApplication.Insert(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customersApplication.Update(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{customerId}")]
        public async Task<IActionResult> Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            var response = await _customersApplication.Delete(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
