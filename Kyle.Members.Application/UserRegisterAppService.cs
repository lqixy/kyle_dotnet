using Kyle.Encrypt.Application.Constructs;
using Kyle.Extensions.Exceptions;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kyle.Identity.Application.Constructs;

namespace Kyle.Members.Application
{
    public class UserRegisterAppService : IUserRegisterAppService
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IEncryptAppService _encryptAppService;
        private readonly IUserOperationRepository _userOperationRepository;
        private readonly IIdentityClientAppService _identityClientAppService;

        public UserRegisterAppService(IUserQueryRepository userQueryRepository, IEncryptAppService encryptAppService,
            IUserOperationRepository userOperationRepository, IIdentityClientAppService identityClientAppService)
        {
            _userQueryRepository = userQueryRepository;
            _encryptAppService = encryptAppService;
            _userOperationRepository = userOperationRepository;
            _identityClientAppService = identityClientAppService;
        }

        public async Task<UserInfoDto> Register(RegisterInputDto input)
        {
            var user = await _userQueryRepository.Get(x => x.UserName == input.Account);
            if (user != null)
            {
                throw new UserFriendlyException("用户名已存在");
            }

            var entity = new UserInfo(input.Account, _encryptAppService.CreatePasswordHash(input.Password),
                Guid.NewGuid());
            entity.AddRegisterRecord();

            await _userOperationRepository.Insert(entity);
            return new UserInfoDto(entity.UserId, entity.UserName, entity.Pwd);
        }

        // public async Task<LoginedOutput> Authorization(UserInfoDto user)
        // {
        //     var token = await _identityClientAppService.Authorization(user.UserId.ToString(), user.Pwd);
        //     if (string.IsNullOrWhiteSpace(token?.AccessToken))
        //         throw new UserFriendlyException("授权服务器返回错误!");
        //
        //     return new LoginedOutput()
        //     {
        //         Key = token.AccessToken,
        //         ExpiresTime = token.ExpiresIn,
        //         UserId = user.UserId
        //     };
        // }
    }
}