using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using Application.Responses;

namespace Application.CQRS.Godowns.Commands.DeleteGodown
{
    public class DeleteGodownCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}