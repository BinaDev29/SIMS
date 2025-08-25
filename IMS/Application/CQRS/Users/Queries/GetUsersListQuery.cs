using MediatR;
using System.Collections.Generic;
using Application.DTOs.Users;

namespace Application.CQRS.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<IReadOnlyList<UserListDto>>
    {
    }
}