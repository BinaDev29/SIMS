// Application/CQRS/Users/Queries/GetUserByUsernameQuery.cs
using MediatR;
using Domain.Models;

namespace Application.CQRS.Users.Queries
{
    public class GetUserByUsernameQuery : IRequest<Employee>
    {
        public string Username { get; set; }

        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}