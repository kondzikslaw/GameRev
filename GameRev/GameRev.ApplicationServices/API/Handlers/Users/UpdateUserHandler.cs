using AutoMapper;
using GameRev.ApplicationServices.API.Domain.Requests.Users;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using GameRev.DataAccess.CQRS;
using GameRev.DataAccess.CQRS.Commands;
using GameRev.DataAccess.Entities;
using MediatR;

namespace GameRev.ApplicationServices.API.Handlers.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly ICommandExecutor _commandExecutor;

        private readonly IMapper _mapper;

        public UpdateUserHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            _commandExecutor = commandExecutor;
            _mapper = mapper;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var mappedUser = _mapper.Map<User>(request);
            var command = new UpdateUserCommand()
            {
                Parameter = mappedUser
            };

            var updatedCommand = await _commandExecutor.Execute(command);

            return new UpdateUserResponse
            {
                Data = _mapper.Map<Domain.Models.User>(updatedCommand)
            };
        }
    }
}
