using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Application.Constructs.Dtos;
using Kyle.Extensions.Exceptions;

namespace Kyle.Members.Application.Test;

[TestClass]
public class MembersTest : MembersTestBase
{
    private readonly IMemberAppService _appService;

    public MembersTest()
    {
        _appService = Provider.GetRequiredService<IMemberAppService>();
    }

    [TestMethod]
    public async Task When_Register_Should_OK()
    {
        await _appService.Register(new RegisterInputDto()
        {
            Mobile = "15555555555",
            Password = "123456"
        });
    }

    [TestMethod]
    public async Task When_Login_Should_OK()
    {
      var result =  await _appService.Login(new LoginInputDto()
        {
            Account = "155",
            Password = "1234"
        });

        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task When_Login_Throw()
    {
        var action = () => _appService.Login(new LoginInputDto
        {
            Account = "155",
            Password = "1234"
        });
       await Assert.ThrowsExceptionAsync<UserFriendlyException>( action);
    }
}