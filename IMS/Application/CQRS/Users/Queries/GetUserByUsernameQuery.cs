using MediatR;
using Domain.Models; // Changed to return the full User model

namespace Application.CQRS.Users.Queries.GetUserByUsername
{
    public class GetUserByUsernameQuery : IRequest<User> // Changed the return type to User
    {
        public string Username { get; set; }

        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}