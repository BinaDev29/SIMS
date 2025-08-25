using Application.Responses; // Namespace corrected
using Application.Contracts;
using Application.DTOs.Items;
using Application.DTOs.Items.Validators; // New using for validation
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq; // New using for validation
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IGenericRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            // Add validation
            var validator = new UpdateItemDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var itemToUpdate = await _itemRepository.GetByIdAsync(request.ItemDto.Id, cancellationToken);

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            _mapper.Map(request.ItemDto, itemToUpdate);
            await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);

            response.Success = true;
            response.Message = "Item Updated Successfully";

            return response;
        }
    }
}