using Kyle.Members.Application.Constructs.Dtos;

namespace Kyle.Members.Application.Constructs;

public interface IMemberAppService
{
    Task<MemberDto> Get(long id);
    
    Task<MemberDto> Register(RegisterInputDto input);

    Task<MemberDto> Login(LoginInputDto input);

    Task<LoginOutputDto> Authorization(MemberDto dto);

    Task Add(MemberDto dto);

    Task Update(MemberDto dto);
}