using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests;
using GameRev.DataAccess.Entities;

namespace GameRev.ApplicationServices.Mappings
{
    public class ReviewsProfile : Profile
    {
        public ReviewsProfile()
        {
            CreateMap<Review, API.Domain.Models.Review>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Content, y => y.MapFrom(z => z.Content))
                .ForMember(x => x.Rate, y => y.MapFrom(z => z.Rate))
                .ForMember(x => x.PublishDate, y => y.MapFrom(z => z.PublishDate))
                .ForMember(x => x.AuthorId, y => y.MapFrom(z => z.AuthorId));

            CreateMap<AddReviewsRequest, Review>()
                .ForMember(x => x.GameId, y => y.MapFrom(z => z.GameId))
                .ForMember(x => x.Content, y => y.MapFrom(z => z.Content))
                .ForMember(x => x.Rate, y => y.MapFrom(z => z.Rate))
                .ForMember(x => x.PublishDate, y => y.MapFrom(z => z.PublishDate))
                .ForMember(x => x.AuthorId, y => y.MapFrom(z => z.AuthorId));
        }
    }
}
