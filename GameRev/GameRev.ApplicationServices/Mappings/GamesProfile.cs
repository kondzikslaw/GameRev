using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Models;

namespace GameRev.ApplicationServices.Mappings
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<GameRev.DataAccess.Entities.Game, Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(z => z.ReleaseDate));
        }
    }
}
