using OnlineLearningPlatform.BLL.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.BLL.Managers.Auth
{
    public interface IAuthManager
    {
        Task<AccountDataModel> Login(LoginDto loginDto);
        Task<AccountDataModel> Register(RegisterDto registerDto);
    }
}
