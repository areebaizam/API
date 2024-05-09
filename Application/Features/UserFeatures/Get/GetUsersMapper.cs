using AutoMapper;
using Domain.Entities;

namespace Application.Features.UserFeatures
{
    public sealed class GetUsersMapper : Profile
    {
        public GetUsersMapper()
        {
            CreateMap<User, GetUsersResponse>()
                .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.Id.Value));
        }
    }
}
