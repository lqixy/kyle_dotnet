using Kyle.Identity.Application;
using Kyle.Members.Application.Constructs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kyle.Mall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : MallControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IUserRegisterAppService _registerAppService;
        private readonly Lazy<TokenCookieHelper> tokenCookieHelper;

        public AccountController(IUserAppService userAppService, IUserRegisterAppService registerAppService
            ,Lazy<TokenCookieHelper> tokenCookieHelper
            )
        {
            _userAppService = userAppService;
            _registerAppService = registerAppService;
            this.tokenCookieHelper = tokenCookieHelper;
        }
        //
        // [HttpPost("register")]
        // public async Task<LoginedOutput> Register(RegisterInputDto input)
        // {
        //     var user = await _registerAppService.Register(input);
        //
        //     // var result = await _registerAppService.Authorization(user);
        //     tokenCookieHelper.Value.Write(HttpContext, result.Key);
        //     return result;
        // }
    }
}