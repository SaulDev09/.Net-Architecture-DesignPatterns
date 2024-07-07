using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Saul.Test.Application.DTO;
using Saul.Test.Application.Interface;

namespace Saul.Test.Services.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly ICustomersApplication _customersApplication;

        public CustomersController(ICustomersApplication customersApplication)
        {
            _customersApplication = customersApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> Get(string customerId)
        {
            var response = await _customersApplication.Get(customerId);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customersApplication.Insert(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
                return BadRequest();

            var response = await _customersApplication.Update(customersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("{customerId}")]
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
