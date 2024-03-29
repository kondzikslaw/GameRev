﻿using GameRev.ApplicationServices.API.Domain.Responses.Users;
using MediatR;

namespace GameRev.ApplicationServices.API.Domain.Requests.Users
{
    public class GetUserByIdRequest : RequestBase, IRequest<GetUserByIdResponse>
    {
        public int Id { get; set; }
    }
}
