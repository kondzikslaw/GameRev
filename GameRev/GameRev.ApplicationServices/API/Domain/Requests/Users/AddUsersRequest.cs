using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Users
{
    public class AddUsersRequest : RequestBase, IRequest<AddUsersResponse>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public bool IsBlocked { get; set; } = false;

        public UserRole UserRole { get; set; } = UserRole.User;
    }
}
