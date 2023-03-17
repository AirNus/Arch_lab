using Arch_lab.Models.DAL.Interfaces;
using Arch_lab.Models.Enum;
using Arch_lab.Models.Response;
using Arch_lab.Models.ViewModel;
using Arch_lab.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Security.Claims;
using Arch_lab.Crypto;
using Arch_lab.Models;
using Microsoft.EntityFrameworkCore;

namespace Arch_lab.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository<Client> _clientRepository;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IBaseRepository<Client> clientRepository, ILogger<AccountService> logger)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            try
            {
                var client = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
                if (client != null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь с таким логином уже есть",
                    };
                }

                client = new Client()
                {
                    Name = model.Name,
                    Passh = HashPassword.GetHash(model.Password),
                    Actual = true
                };

                await _clientRepository.Create(client);

                var result = Authenticate(client);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    Description = "Объект добавился",
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Register]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            try
            {
                var client = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name && x.Actual == true);
                if (client == null)
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Пользователь не найден"
                    };
                }

                if (client.Passh != HashPassword.GetHash(model.Password))
                {
                    return new BaseResponse<ClaimsIdentity>()
                    {
                        Description = "Неверный пароль или логин"
                    };
                }
                var result = Authenticate(client);

                return new BaseResponse<ClaimsIdentity>()
                {
                    Data = result,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[Login]: {ex.Message}");
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<BaseResponse<bool>> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                var client = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.UserName);
                if (client == null)
                {
                    return new BaseResponse<bool>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "Пользователь не найден"
                    };
                }

                client.Passh = HashPassword.GetHash(model.NewPassword);
                await _clientRepository.Update(client);

                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = StatusCode.OK,
                    Description = "Пароль обновлен"
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[ChangePassword]: {ex.Message}");
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        private ClaimsIdentity Authenticate(Client client)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, client.Name),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
            };

            return new ClaimsIdentity(claims, "ApplicationCookie",
                                        ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
