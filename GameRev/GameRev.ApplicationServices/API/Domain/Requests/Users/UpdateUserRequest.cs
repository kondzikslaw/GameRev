using GameRev.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Users
{
    public class UpdateUserRequest : RequestBase, IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
