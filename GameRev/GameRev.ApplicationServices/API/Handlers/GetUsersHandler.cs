using GameRev.ApplicationServices.API.Domain;
using GameRev.DataAccess;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IRepository<User> _userRepository;

        public GetUsersHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            var domainUsers = users.Select(x => new Domain.Models.User()
            {
                Id = x.Id,
                Login = x.Login,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                RegisterDate = x.RegisterDate
            });

            var response = new GetUsersResponse()
            {
                Data = domainUsers.ToList()
            };
            return Task.FromResult(response);
        }
    }
}
