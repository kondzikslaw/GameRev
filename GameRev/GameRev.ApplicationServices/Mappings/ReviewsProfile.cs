using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Models;

namespace GameRev.ApplicationServices.Mappings
{
    public class ReviewsProfile : Profile
    {
        public ReviewsProfile()
        {
            CreateMap<GameRev.DataAccess.Entities.Review, Review>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Content, y => y.MapFrom(z => z.Content))
                .ForMember(x => x.Rate, y => y.MapFrom(z => z.Rate))
                .ForMember(x => x.PublishDate, y => y.MapFrom(z => z.PublishDate))
                .ForMember(x => x.AuthorId, y => y.MapFrom(z => z.AuthorId));
        }
    }
}
