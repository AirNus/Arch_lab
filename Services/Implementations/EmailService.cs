using Arch_lab.Models;
using Arch_lab.Models.Enum;
using Arch_lab.Models.DAL.Interfaces;
using Arch_lab.Models.ViewModel;
using Arch_lab.Services.Interfaces;
using Microsoft.AspNetCore.Components.Routing;
using Arch_lab.Models.Response;
using Microsoft.EntityFrameworkCore;

namespace Arch_lab.Services.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IBaseRepository<Email> _emailRepository;
        private readonly IBaseRepository<Client> _clientRepository;
        private readonly ICryptoService _cryptoService;
        private ILogger<EmailService> _logger;

        public EmailService(IBaseRepository<Email> emailRepository, IBaseRepository<Client> clientRepository, ICryptoService cryptoService, ILogger<EmailService> logger)
        {
            _emailRepository = emailRepository;
            _clientRepository = clientRepository;
            _cryptoService = cryptoService;
            _logger = logger;
        }

        public IBaseResponse<List<EmailViewModel>> GetEmails()
        {
            try
            {
                var emails = _emailRepository.GetAll().ToList();
                var clients =  _clientRepository.GetAll().ToList(); 
                if (!emails.Any())
                {
                    return new BaseResponse<List<EmailViewModel>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }


                var emailsView = new List<EmailViewModel>();

                foreach(var email in emails)
                {
                    emailsView.Add(new EmailViewModel()
                    {
                        EmailId = email.Id,
                        Sender = clients.Where(x => x.Id == email.IdSender).FirstOrDefault().Name,
                        Receiver = clients.Where(x => x.Id == email.IdReceiver).FirstOrDefault().Name,
                        Email = email.Data,
                        Dated = email.Dated,
                        EmailStatus = email.Status
                    });
                }

                return new BaseResponse<List<EmailViewModel>>()
                {
                    Data = emailsView,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<EmailViewModel>>()
                {
                    Description = $"[GetEmails] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Email>> Create(CreateEmailViewModel model)
        {
            try
            {
                _logger.LogInformation($"Запрос на отправку письма - {model.Receiver + model.EmailBody}");

                var receiver = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Receiver);
                var sender = await _clientRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Sender);


                if (receiver == null)
                {
                    return new BaseResponse<Email>()
                    {
                        Description = "Пользователя с таким именем не найдено",
                        StatusCode = StatusCode.UserNotExists
                    };
                }

                var email = new Email()
                {
                    Dated = DateTime.Now,
                    IdSender = sender.Id,
                    Data = model.EmailBody,
                    IdReceiver = receiver.Id,
                    Status = EmailStatus.Unsign
                };

                if (model.CertName != "Без сертификата" && model.CertName != null)
                {
                    var signature = _cryptoService.SignEmail(email, model.CertName);

                    email.Signature = signature.Data.Signature;
                    email.Status = EmailStatus.Sign;

                }

                await _emailRepository.Create(email);


                _logger.LogInformation($"Письмо с id {email.Id} отправлено {receiver.Name}");
                return new BaseResponse<Email>()
                {
                    Description = "Письмо отправлено",
                    StatusCode = StatusCode.OK
                
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[EmailService.Create]: {ex.Message}");
                return new BaseResponse<Email>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
