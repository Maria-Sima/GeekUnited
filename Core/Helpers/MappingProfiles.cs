using AutoMapper;
using Core.Documents;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AppUser, UserDocument>().IncludeAllDerived().ReverseMap();
        CreateMap<Post, PostDocument>().IncludeAllDerived().ReverseMap();
        CreateMap<Board, BoardDocument>().IncludeAllDerived().ReverseMap();
    }
}
