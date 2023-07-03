using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.GameUsers;
using GameRev.DataAccess.Entities;

namespace GameRev.ApplicationServices.Mappings
{
    public class GameUsersProfile : Profile
    {
        public GameUsersProfile()
        {
            CreateMap<GameUser, API.Domain.Models.GameUser>()
                .ForMember(x => x.GameId, y => y.MapFrom(z => z.GameId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));

            CreateMap<AddGameUsersRequest, GameUser>()
                .ForMember(x => x.GameId, y => y.MapFrom(z => z.GameId))
                .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId));
        }
    }
}
