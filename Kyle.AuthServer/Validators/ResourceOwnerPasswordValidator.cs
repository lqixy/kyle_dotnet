using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Kyle.Extensions.Exceptions;
using Kyle.Members.Application;
using Kyle.Members.Application.Constructs;
using Kyle.Members.Application.Constructs.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static IdentityModel.OidcConstants;

namespace Kyle.AuthServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ILogger _logger;
        private readonly IMemberAppService _appService;

        public ResourceOwnerPasswordValidator(
            ILogger<ResourceOwnerPasswordValidator> logger, IMemberAppService appService)
        {
            //_factory = factory;
            _logger = logger;
            this._appService = appService;

        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {

            var result = await CheckPasswordSignIn(context.UserName, context.Password);
            var user = result?.Result;

            if (user != null)
            {
                if (user.Succeeded)
                {
                    _logger.LogInformation($"Credentials validated for username:{context.UserName}");
                    context.Result = new GrantValidationResult(result.SubjectId, AuthenticationMethods.Password
                        , result.Claims);
                    return;
                }
                else if (user.IsLockedOut)
                {
                    _logger.LogInformation($"Authentication failed for username:{context.UserName},reason: locked out");
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, errorDescription: "账号已被锁定");
                }
                else if (user.IsNotAllowed)
                {
                    _logger.LogInformation($"Authentication failed for username:{context.UserName},reason: not allowed");
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, errorDescription: "账号不允许访问");
                }
                else
                {
                    _logger.LogInformation($"Authentication failed for username:{context.UserName},reason: invalid credentials");
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, errorDescription: "账号或密码错误");
                }
            }
            else
            {
                _logger.LogInformation($"No user found matching username:{context.UserName}");
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, errorDescription: "账号或密码错误");
            }

        }


        private async Task<IdentityUserSignInResult> CheckPasswordSignIn(string username, string password)
        {
            var user = await Find(username);
            if (user == null) return null;
            // if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(user.Pwd))
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(user.Password))
            {
                return new IdentityUserSignInResult(SignInResult.Failed);
            }

            // if (string.Compare(user.Pwd.Trim(), password.Trim(), true) != 0)
            if (string.Compare(user.Password.Trim(), password.Trim(), true) != 0)
            {
                return new IdentityUserSignInResult(SignInResult.Failed);
            }

            // if (user.DelStatus.HasValue)
            if (user.Deleted)
            {
                return new IdentityUserSignInResult(SignInResult.NotAllowed);
            }

            return new IdentityUserSignInResult(SignInResult.Success)
            {
                // SubjectId = $"{user.UserId}",
                SubjectId = $"{user.Id}",
                Claims = new Claim[]
                {
                new Claim(JwtClaimTypes.Name, user.UserName ?? "not set"),
                new Claim(JwtClaimTypes.Role, "User"),
                    // new Claim("tenantId", user.TenantId.ToString())
                }
            };
        }


        private async Task<MemberDto> Find(string userId)
        {
            if (long.TryParse(userId, out long id))
            {
                return await _appService.Get(id);
            }

            throw new UserFriendlyException($"未找到用户: {userId}");
        }


    }
}