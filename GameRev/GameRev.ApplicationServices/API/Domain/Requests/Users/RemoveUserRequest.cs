﻿using GameRev.ApplicationServices.API.Domain.Responses;
using GameRev.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Users
{
    public class RemoveUserRequest : RequestBase, IRequest<RemoveUserResponse>
    {
        public int Id { get; set; }
    }
}
