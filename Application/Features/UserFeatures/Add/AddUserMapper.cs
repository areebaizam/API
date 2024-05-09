using AutoMapper;
using Domain.Entities;
namespace Application.Features.UserFeatures
{
    public sealed class AddUserMapper : Profile
    {
        public AddUserMapper()
        {
            CreateMap<AddUserRequest, User>();

            CreateMap<UserId, AddUserResponse>()
                .ForMember(dest => dest.UserId,
                opt => opt.MapFrom(src => src.Value));
        }
    }
}
