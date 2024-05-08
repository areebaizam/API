﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures
{
    public sealed record GetUserByIdQuery(GetUserRequest UserId) : IRequest<GetUserResponse>;
}