using GameRev.ApplicationServices.API.Domain.Models;
using GameRev.ApplicationServices.API.Domain.Responses.GameUsers;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.GameUsers
{
    public class AddGameUsersRequest : RequestBase, IRequest<AddGameUsersResponse>
    {
        public int GameId { get; set; }

        public int UserId { get; set; }

        public GameUserRole Role { get; set; }
    }
}
