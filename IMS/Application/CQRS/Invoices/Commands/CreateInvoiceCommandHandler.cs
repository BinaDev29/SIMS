using AutoMapper;
using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading.Tasks;
using System.Threading;
using Application.DTOs.Invoices.Validators;
using System.Linq;
using System;

namespace Application.CQRS.Invoices.Commands
{
    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, BaseCommandResponse>
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository, IItemRepository itemRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateInvoiceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.InvoiceDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var invoice = _mapper.Map<Invoice>(request.InvoiceDto);

            // የእያንዳንዱን እቃ ክምችት መቀነስ
            foreach (var detail in invoice.InvoiceDetails)
            {
                var itemToUpdate = await _itemRepository.GetByIdAsync(detail.ItemId, cancellationToken);

                if (itemToUpdate == null)
                {
                    response.Success = false;
                    response.Message = $"Item with ID {detail.ItemId} not found.";
                    return response;
                }

                if (itemToUpdate.StockQuantity < detail.Quantity)
                {
                    response.Success = false;
                    response.Message = $"Insufficient stock for Item {itemToUpdate.ItemName}. Available: {itemToUpdate.StockQuantity}, Requested: {detail.Quantity}";
                    return response;
                }

                itemToUpdate.StockQuantity -= detail.Quantity;
                await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);
            }

            // የጠቅላላ ዋጋን እና የinvoice ቁጥርን በሰርቨሩ ላይ ማስላት
            invoice.TotalAmount = invoice.InvoiceDetails.Sum(d => d.Quantity * d.UnitPrice);
            invoice.InvoiceNumber = Guid.NewGuid().ToString();

            await _invoiceRepository.AddAsync(invoice, cancellationToken);

            response.Success = true;
            response.Message = "Invoice Created Successfully";
            response.Id = invoice.Id;

            return response;
        }
    }
}