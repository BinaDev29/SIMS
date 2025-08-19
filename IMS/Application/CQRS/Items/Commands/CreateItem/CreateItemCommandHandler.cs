using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Items;
using Application.Responses; // Changed to Responses
using Application.Exceptions;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, BaseCommandResponse> // Changed to BaseCommandResponse
    {
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IGenericRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken) // Changed to BaseCommandResponse
        {
            var response = new BaseCommandResponse(); // Changed to BaseCommandResponse
            var item = _mapper.Map<Item>(request.ItemDto);

            await _itemRepository.AddAsync(item);

            response.Success = true;
            response.Message = "Item Created Successfully";

            return response;
        }
    }
}