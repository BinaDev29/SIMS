using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Items;
using Application.Responses; // Changed to Responses
using Application.Exceptions;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, BaseCommandResponse> // Changed to BaseCommandResponse
    {
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IGenericRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateItemCommand request, CancellationToken cancellationToken) // Changed to BaseCommandResponse
        {
            var response = new BaseCommandResponse(); // Changed to BaseCommandResponse
            var itemToUpdate = await _itemRepository.GetByIdAsync(request.ItemDto.Id);

            if (itemToUpdate == null)
            {
                response.Success = false;
                response.Message = "Item not found.";
                return response;
            }

            _mapper.Map(request.ItemDto, itemToUpdate);
            await _itemRepository.UpdateAsync(itemToUpdate);

            response.Success = true;
            response.Message = "Item Updated Successfully";

            return response;
        }
    }
}