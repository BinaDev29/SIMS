using MediatR;
using AutoMapper;
using Application.Contracts;
using Application.DTOs.Items;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CQRS.Items.Queries.GetItemsList
{
    public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, IReadOnlyList<ItemDto>>
    {
        private readonly IGenericRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsListQueryHandler(IGenericRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ItemDto>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<IReadOnlyList<ItemDto>>(items);
        }
    }
}