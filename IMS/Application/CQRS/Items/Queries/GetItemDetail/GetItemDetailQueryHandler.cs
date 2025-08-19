using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Items;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.Items.Queries.GetItemDetail
{
    public class GetItemDetailQueryHandler : IRequestHandler<GetItemDetailQuery, ItemDto>
    {
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public GetItemDetailQueryHandler(IGenericRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemDto> Handle(GetItemDetailQuery request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetByIdAsync(request.Id);
            if (item == null)
            {
                throw new NotFoundException(nameof(Item), request.Id);
            }
            return _mapper.Map<ItemDto>(item);
        }
    }
}