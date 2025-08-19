using Application.CQRS.Supplier.Commands.CreateSupplier;
using Application.CQRS.Supplier.Commands.DeleteSupplier;
using Application.CQRS.Supplier.Commands.UpdateSupplier;
using Application.CQRS.Supplier.Queries.GetSupplierDetail;
using Application.CQRS.Supplier.Queries.GetSuppliersList;
using Application.DTOs.Suppliers;
using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SupplierController : BaseApiController
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SupplierDto>>> Get()
        {
            var query = new GetSuppliersListQuery();
            var suppliers = await _mediator.Send(query);
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> Get(int id)
        {
            var query = new GetSupplierDetailQuery { Id = id };
            var supplier = await _mediator.Send(query);
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateSupplierDto createSupplierDto)
        {
            var command = new CreateSupplierCommand { SupplierDto = createSupplierDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] UpdateSupplierDto updateSupplierDto)
        {
            var command = new UpdateSupplierCommand { SupplierDto = updateSupplierDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var command = new DeleteSupplierCommand { Id = id };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}