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
                .ForMember(x => x.ReleaseYear, y => y.MapFrom(z => z.ReleaseYear));

            CreateMap<AddGamesRequest, Game>()
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ReleaseYear, y => y.MapFrom(z => z.ReleaseYear));

            CreateMap<UpdateGameRequest, Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ReleaseYear, y => y.MapFrom(z => z.ReleaseYear));

            CreateMap<RemoveGameRequest, Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));

            CreateMap<Game, API.Domain.Models.Game>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.ReleaseYear, y => y.MapFrom(z => z.ReleaseYear))
                .ForMember(x => x.Genres, y => y.MapFrom(z => z.Genres != null ? z.Genres.Select(x => x.Name) : new List<string>()))
                .ForMember(x => x.Rate, y => y.MapFrom(z => z.Reviews != null ? z.Reviews.Select(x => x.Rate).Average() : 0))
                .ForMember(x => x.Reviews, y => y.MapFrom(z => z.Reviews != null ? z.Reviews.Select(x => x.Content) : new List<string>()));
        }
    }
}
