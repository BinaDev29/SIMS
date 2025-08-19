using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Application.DTOs.Godowns;
using Application.Responses;

namespace Application.CQRS.Godowns.Commands.CreateGodown
{
    public class CreateGodownCommand : IRequest<BaseCommandResponse>
    {
        public required CreateGodownDto GodownDto { get; set; }
    }
}