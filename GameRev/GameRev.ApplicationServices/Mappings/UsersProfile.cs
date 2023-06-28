using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.DataAccess.Entities;

namespace GameRev.ApplicationServices.Mappings
{
    public class UsersProfile :Profile
    {
        public UsersProfile()
        {
            CreateMap<User, API.Domain.Models.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.RegisterDate, y => y.MapFrom(z => z.RegisterDate))
                //.ForMember(x => x.Games, y => y.MapFrom(z => z.Games))
                .ForMember(x => x.UserRole, y => y.MapFrom(z => z.UserRole));

            CreateMap<AddUsersRequest, User>()
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.RegisterDate, y => y.MapFrom(z => z.RegisterDate));
                //.ForMember(x => x.Games, y => y.MapFrom(z => z.Games));

            CreateMap<RemoveUserRequest, User>()
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login));

            CreateMap<UpdateUserRequest, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Login, y => y.MapFrom(z => z.Login))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Surname, y => y.MapFrom(z => z.Surname))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.RegisterDate, y => y.MapFrom(z => z.RegisterDate))
                //.ForMember(x => x.Games, y => y.MapFrom(z => z.Games))
                .ForMember(x => x.UserRole, y => y.MapFrom(z => z.UserRole));
        }
    }
}
