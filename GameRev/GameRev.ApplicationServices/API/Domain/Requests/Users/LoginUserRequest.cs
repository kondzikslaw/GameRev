using GameRev.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Users
{
    public class LoginUserRequest : RequestBase, IRequest<LoginUserResponse>
    {
        public string Login { get; set; }

        public string Password { get; set; }
    }
}
