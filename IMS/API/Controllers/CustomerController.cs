using Application.CQRS.Customers.Commands.CreateCustomer;
using Application.CQRS.Customers.Commands.DeleteCustomer;
using Application.CQRS.Customers.Commands.UpdateCustomer;
using Application.CQRS.Customers.Queries.GetCustomerDetail;
using Application.CQRS.Customers.Queries.GetCustomersList;
using Application.DTOs.Customers;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomerController : BaseApiController
    {
        // IMediatorን ከ BaseApiController ስለምትወርስ constructorም ሆነ የ _mediator ንብረቱን እንደገና መግለጽ አያስፈልግም
        // በቀጥታ _mediatorን መጠቀም ትችላለህ።

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CustomerDto>>> Get()
        {
            var query = new GetCustomersListQuery();
            var customers = await Mediator.Send(query);
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(int id)
        {
            var query = new GetCustomerDetailQuery { Id = id };
            var customer = await Mediator.Send(query);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCustomerDto createCustomerDto)
        {
            var command = new CreateCustomerCommand { CustomerDto = createCustomerDto };
            var response = await Mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var command = new UpdateCustomerCommand { CustomerDto = updateCustomerDto };
            var response = await Mediator.Send(command);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}