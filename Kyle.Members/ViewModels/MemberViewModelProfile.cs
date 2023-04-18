using AutoMapper;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Application.Constructs.Dtos;

namespace Kyle.Members.ViewModels;

public class MemberViewModelProfile: Profile
{
    public MemberViewModelProfile()
    {
        CreateMap<RegisterInput, RegisterInputDto>();
        CreateMap<RegisterInputDto, RegisterInput>();

        CreateMap<LoginInput, LoginInputDto>();
        CreateMap<LoginInputDto, LoginInput>();

        CreateMap<LoginOutputDto, LoginOutputViewModel>();
        CreateMap<LoginOutputViewModel, LoginOutputDto>();
         
    }
    
}