using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Models;

namespace GameRev.ApplicationServices.Mappings
{
    public class UsersProfile :Profile
    {
        public UsersProfile()
        {
            CreateMap<GameRev.DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.RegisterDate, y => y.MapFrom(z => z.RegisterDate));
        }
    }
}
