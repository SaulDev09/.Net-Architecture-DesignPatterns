using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saul.Test.Application.UseCases.Customers.Commands.CreateCustomerCommand;
using Saul.Test.Application.UseCases.Customers.Commands.DeleteCustomerCommand;
using Saul.Test.Application.UseCases.Customers.Commands.UpdateCustomerCommand;
using Saul.Test.Application.UseCases.Customers.Queries.GetAllCustomerQuery;
using Saul.Test.Application.UseCases.Customers.Queries.GetAllWithPaginationCustomerQuery;
using Saul.Test.Application.UseCases.Customers.Queries.GetCustomerQuery;

namespace Saul.Test.Services.WebAPI.Controllers.v3
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("3.0")]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            //var response = await _customersApplication.GetAll();
            var response = await _mediator.Send(new GetAllCustomerQuery());
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            //var response = await _customersApplication.GetAllWithPagination(pageNumber, pageSize);
            var response = await _mediator.Send(new GetAllWithPaginationCustomerQuery() { PageNumber = pageNumber, PageSize = pageSize });
            if (response.IsSuccess)
            {
                //_logger.LogInfo("Test LogInfo GetAllWithPagination - request processed.");
                return Ok(response);
            }

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{customerId}")]
        public async Task<IActionResult> Get([FromRoute] string customerId)
        {
            //var response = await _customersApplication.Get(customerId);
            var response = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);

        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateCustomerCommand command)
        {
            if (command == null)
                return BadRequest();

            //var response = await _customersApplication.Insert(customersDto);
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update/{customerId}")]
        public async Task<IActionResult> Update(string customerId, [FromBody] UpdateCustomerCommand command)
        {
            //var customerDto = await _customersApplication.Get(customerId);
            var customerDto = await _mediator.Send(new GetCustomerQuery() { CustomerId = customerId });

            if (customerDto.Data == null)
                return NotFound(customerDto.Message);

            if (command == null)
                return BadRequest();

            //var response = await _customersApplication.Update(customersDto);
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{customerId}")]
        public async Task<IActionResult> Delete([FromRoute] string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
                return BadRequest();

            //var response = await _customersApplication.Delete(customerId);
            var response = await _mediator.Send(new DeleteCustomerCommand() { CustomerId = customerId });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

    }
}
