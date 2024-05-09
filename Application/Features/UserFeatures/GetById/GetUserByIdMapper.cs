using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures
{
    public sealed class GetUserByIdMapper : Profile
    {
        public GetUserByIdMapper() {

            CreateMap<GetUserRequest, UserId>()
                .ForMember(dest=>dest.Value,
                opt => opt.MapFrom(src => src.UserId));

            CreateMap<User, GetUserResponse>();
        }
    }
}
