using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Games;
using GameRev.DataAccess.Entities;

namespace GameRev.ApplicationServices.Mappings
{
    public class GamesProfile : Profile
    {
        public GamesProfile()
        {
            CreateMap<Game, API.Domain.Models.Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(z => z.ReleaseDate));

            CreateMap<AddGamesRequest, Game>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(z => z.ReleaseDate));

            CreateMap<UpdateGameRequest, Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ReleaseDate, y => y.MapFrom(z => z.ReleaseDate));

            CreateMap<RemoveGameRequest, Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
