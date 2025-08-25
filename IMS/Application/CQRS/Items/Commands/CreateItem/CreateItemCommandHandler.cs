using Application.Responses;
using Application.Contracts;
using Application.DTOs.Items.Validators; // New using statement for validation
using Application.Exceptions;
using AutoMapper;
using Domain.Models;
using MediatR;
using System.Linq; // New using statement for validation
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public CreateItemCommandHandler(IGenericRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateItemDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ItemDto, cancellationToken);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var item = _mapper.Map<Item>(request.ItemDto);

            await _itemRepository.AddAsync(item, cancellationToken);

            response.Success = true;
            response.Message = "Item Created Successfully";
            response.Id = item.Id; // Correctly return the ID of the new item

            return response;
        }
    }
}