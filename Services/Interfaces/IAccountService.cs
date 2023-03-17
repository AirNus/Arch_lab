using Arch_lab.Models.Response;
using Arch_lab.Models.ViewModel;
using System.Security.Claims;

namespace Arch_lab.Services.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);

        Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model);
    }
}
