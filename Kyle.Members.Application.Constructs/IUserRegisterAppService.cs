﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyle.Members.Application.Constructs
{
    public interface IUserRegisterAppService
    {
        Task<UserInfoDto> Register(RegisterInputDto input);

        // Task<LoginedOutput> Authorization(UserInfoDto user);
    }
}