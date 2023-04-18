using AutoMapper;
using Kyle.Extensions.Exceptions;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Application.Constructs.Dtos;
using Kyle.Members.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Kyle.Members.Controllers;

[Route("api/member")]
[ApiController]
public class MemberController : ControllerBase
{
    private readonly IMemberAppService _appService;
    private readonly IMapper _mapper;

    public MemberController(IMemberAppService appService, IMapper mapper)
    {
        _appService = appService;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task Register(RegisterInput input)
    {
        var dto = _mapper.Map<RegisterInputDto>(input);
        await _appService.Register(dto);
    }

    [HttpPost("login")]
    public async Task<LoginOutputViewModel> Login(LoginInput input)
    {
        var dto = _mapper.Map<LoginInputDto>(input);
        var memberDto = await _appService.Login(dto);

        var authResult = await _appService.Authorization(memberDto);

        return _mapper.Map<LoginOutputViewModel>(authResult);
    }
}