using AutoMapper;
using Kyle.Members.Domain;

namespace Kyle.Members.Application.Constructs.Dtos;

public class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<Member,MemberDto>();
        CreateMap<MemberDto,Member>();
    }
}