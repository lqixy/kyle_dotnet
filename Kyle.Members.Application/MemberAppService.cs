using AutoMapper;
using Kyle.Common;
using Kyle.Encrypt.Application.Constructs;
using Kyle.Extensions.Exceptions;
using Kyle.Identity.Application.Constructs;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Application.Constructs.Dtos;
using Kyle.Members.Domain;

namespace Kyle.Members.Application;

public class MemberAppService : IMemberAppService
{
    private readonly IMemberRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILongGenerator _generator;
    private readonly IEncryptAppService _encryptAppService;
    private readonly IIdentityClientAppService _identityClientAppService;

    public MemberAppService(IMemberRepository repository, IMapper mapper, ILongGenerator generator,
        IEncryptAppService encryptAppService
        , IIdentityClientAppService identityClientAppService
        )
    {
        _repository = repository;
        _mapper = mapper;
        _generator = generator;
        _encryptAppService = encryptAppService;
        _identityClientAppService = identityClientAppService;
    }

    public async Task<MemberDto> Get(long id)
    {
        var entity = await _repository.Get(id);

        return _mapper.Map<MemberDto>(entity);
    }

    public async Task<MemberDto> Register(RegisterInputDto input)
    {
        var exists = await _repository
            .Get(x => (x.Account == input.Account && x.Account != null) ||
                      (x.Mobile == input.Mobile && x.Mobile != null));
        if (exists is not null) throw new UserFriendlyException("用户名已存在");

        var dto = new MemberDto(_generator.Create(), _encryptAppService.CreatePasswordHash(input.Password),
            account: input.Account, mobile: input.Mobile);
        await Add(dto);
        return dto;
    }

    public async Task<LoginOutputDto> Authorization(MemberDto dto)
    {
        var token = await _identityClientAppService.Authorization(dto.Id, dto.Password);
        if (string.IsNullOrWhiteSpace(token?.AccessToken))
            throw new UserFriendlyException("授权失败!");
        return new LoginOutputDto()
        {
            Key = token.AccessToken,
            UserId = dto.Id,
            ExpiresTime = token.ExpiresIn
        };
    }

    public async Task<MemberDto> Login(LoginInputDto input)
    {
        var member = await _repository
            .Get(input.Account);

        if (member is null)
            throw new UserFriendlyException("用户不存在");

        if (!_encryptAppService
                .ValidatePasswordHash(input.Password, member.Password))
            throw new UserFriendlyException("用户名或密码不正确");
        return _mapper.Map<MemberDto>(member);
    }

    public async Task Add(MemberDto dto)
    {
        var entity = _mapper.Map<Member>(dto);
        await _repository.Add(entity);
    }

    public async Task Update(MemberDto dto)
    {
        var entity = _mapper.Map<Member>(dto);
        await _repository.Update(entity);
    }
}