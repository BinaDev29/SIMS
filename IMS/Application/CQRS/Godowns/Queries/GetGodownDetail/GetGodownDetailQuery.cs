// Application/CQRS/Godowns/Queries/GetGodownDetail/GetGodownDetailQuery.cs
using MediatR;
using Application.DTOs.Godowns;

namespace Application.CQRS.Godowns.Queries.GetGodownDetail
{
    public class GetGodownDetailQuery : IRequest<GodownDto> // Added public
    {
        public required int Id { get; set; } // Added public
    }
}