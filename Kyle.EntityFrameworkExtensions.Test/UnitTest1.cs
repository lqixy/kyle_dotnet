using Kyle.EntityFrameworkExtensions.Test.Models;
using Kyle.EntityFrameworkExtensions.Test.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Kyle.EntityFrameworkExtensions.Test
{
    [TestClass]
    public class UnitTest1 : TestBase
    {
        private readonly UserInfoRepository _userInfoRepository;
        private readonly TodoRepository _todoRepository;

        public UnitTest1()
        {
            _userInfoRepository = Provider.GetRequiredService<UserInfoRepository>();
            _todoRepository = Provider.GetRequiredService<TodoRepository>();
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            var list = await _userInfoRepository.Get();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public async Task When_User_Save_Should_OK()
        {
          var result =  await _userInfoRepository.Save(
                new UserInfo(Guid.NewGuid(),"Kyle","pwd"));
          Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task When_Get_Todos_Should_OK()
        {
            var list = await _todoRepository.Get();
            Assert.IsTrue(!list.Any());
        }
    }
}