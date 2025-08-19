using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Application.Contracts;
using Application.Responses;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.CQRS.Godowns.Commands.DeleteGodown
{
    public class DeleteGodownCommandHandler : IRequestHandler<DeleteGodownCommand, BaseCommandResponse>
    {
        private readonly IGenericRepository<Godown> _godownRepository;

        public DeleteGodownCommandHandler(IGenericRepository<Godown> godownRepository)
        {
            _godownRepository = godownRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteGodownCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var godownToDelete = await _godownRepository.GetByIdAsync(request.Id);

            if (godownToDelete == null)
            {
                response.Success = false;
                response.Message = "Godown not found.";
                return response;
            }

            await _godownRepository.DeleteAsync(godownToDelete);

            response.Success = true;
            response.Message = "Godown Deleted Successfully";
            return response;
        }
    }
}