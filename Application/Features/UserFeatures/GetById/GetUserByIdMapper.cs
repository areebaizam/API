using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures
{
    public sealed class GetUserByIdMapper : Profile
    {
        public GetUserByIdMapper() {

            CreateMap<GetUserByIdQuery, UserId>()
                .ForMember(dest=>dest.Value,
                opt => opt.MapFrom(src => src.request.UserId));

            CreateMap<User, GetUserResponse>()
                .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.Id.Value));
        }
    }
}
