using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Application.DTOs.Godowns;
using Application.Responses;

namespace Application.CQRS.Godowns.Commands.UpdateGodown
{
    public class UpdateGodownCommand : IRequest<BaseCommandResponse>
    {
        public required UpdateGodownDto GodownDto { get; set; }
    }
}