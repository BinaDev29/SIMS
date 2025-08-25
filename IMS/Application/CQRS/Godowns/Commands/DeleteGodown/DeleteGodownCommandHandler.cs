using Application.Contracts;
using Application.Exceptions;
using Application.Responses;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks;

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
            // Passing the cancellation token
            var godownToDelete = await _godownRepository.GetByIdAsync(request.Id, cancellationToken);

            if (godownToDelete == null)
            {
                response.Success = false;
                response.Message = "Godown not found.";
                return response;
            }

            // Passing the cancellation token
            await _godownRepository.DeleteAsync(godownToDelete, cancellationToken);

            response.Success = true;
            response.Message = "Godown Deleted Successfully";
            return response;
        }
    }
}