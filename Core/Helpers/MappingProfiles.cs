using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<Post, PostDto>()
            .ForMember(d => d.Board, o => o.MapFrom(s => s.Board.BoardName))
            .ForMember(d => d.User, o => o.MapFrom(s => s.AppUser.Username));
        

    }
    
}