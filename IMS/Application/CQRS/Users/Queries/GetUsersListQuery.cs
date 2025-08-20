// Application/CQRS/Users/Queries/GetUsersListQuery.cs
using MediatR;
using System.Collections.Generic;
using Application.DTOs.Users;

namespace Application.CQRS.Users.Queries
{
    public class GetUsersListQuery : IRequest<IReadOnlyList<UserListDto>>
    {
    }
}