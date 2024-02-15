using AFI.Demo.DataAccess;
using AutoMapper;

namespace AFI.Demo.MappingProfiles;

public class UserProfiles : Profile
{
    public UserProfiles()
    {
        CreateMap<User, ViewModels.User>().ReverseMap();
        CreateMap<User, ViewModels.UserPutInput>().ReverseMap();
    }
}
