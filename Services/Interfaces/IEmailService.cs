using Arch_lab.Models;
using Arch_lab.Models.Response;
using Arch_lab.Models.ViewModel;

namespace Arch_lab.Services.Interfaces
{
    public interface IEmailService
    {
        Task<IBaseResponse<Email>> Create(CreateEmailViewModel model);

        IBaseResponse<List<EmailViewModel>> GetEmails();
    }
}
