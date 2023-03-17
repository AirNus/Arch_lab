using Arch_lab.Models;
using Arch_lab.Models.Response;
using Arch_lab.Models.ViewModel;
using System.Security.Cryptography;

namespace Arch_lab.Services.Interfaces
{
    public interface ICryptoService
    {
        Task<IBaseResponse<bool>> VerifySignature(VerifyEmailViewModel model);

        Task<IBaseResponse<Certificate>> CreateKey(string sertName);

        IBaseResponse<Email> SignEmail(Email email, string certName);

        IBaseResponse<List<Certificate>> GetCerts();
    }
}
