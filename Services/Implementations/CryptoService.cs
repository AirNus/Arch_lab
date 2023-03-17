using Arch_lab.Crypto;
using Arch_lab.Models;
using Arch_lab.Models.DAL.Interfaces;
using Arch_lab.Models.DAL.Repositories;
using Arch_lab.Models.Enum;
using Arch_lab.Models.Response;
using Arch_lab.Models.ViewModel;
using Arch_lab.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Arch_lab.Services.Implementations
{
    public class CryptoService : ICryptoService
    {
        private readonly IBaseRepository<Models.PublicKey> _publicKeyRepository;
        private readonly IBaseRepository<PrivateKey> _privateKeyRepository;
        private readonly IBaseRepository<Email> _emailRepository;
        private readonly IBaseRepository<Certificate> _certificateRepository;
        ILogger<CryptoService> _logger;

        public CryptoService(IBaseRepository<Client> clientRepository, IBaseRepository<Email> emailRepository, IBaseRepository<Models.PublicKey> publicKeyRepository, IBaseRepository<PrivateKey> privateKeyRepository, IBaseRepository<Certificate> keyUserKeyMapRepository, ILogger<CryptoService> logger)
        {
            //_clientRepository = clientRepository;
            _emailRepository = emailRepository;
            _publicKeyRepository = publicKeyRepository;
            _privateKeyRepository = privateKeyRepository;
            _certificateRepository = keyUserKeyMapRepository;
            _logger = logger;
        }

        public IBaseResponse<List<Certificate>> GetCerts()
        {
            try
            {
                var certs = _certificateRepository.GetAll().ToList();
                if (!certs.Any())
                {
                    return new BaseResponse<List<Certificate>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.OK
                    };
                }


                return new BaseResponse<List<Certificate>>()
                {
                    Data = certs,
                    StatusCode = StatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Certificate>>()
                {
                    Description = $"[GetCerts] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Certificate>> CreateKey(string certName)
        {
            try
            {
                var keysDictionary = Signature.AssignNewKey();
                var _publicKey = keysDictionary["publicKey"];
                var _privateKey = keysDictionary["privateKey"];
                
                int publicKeyNewId;
                try { 
                    publicKeyNewId = _publicKeyRepository.GetMaxId(); 
                }
                catch (Exception e)
                {
                    publicKeyNewId = 1;
                }
                int privateKeyNewId;
                try { 
                    privateKeyNewId = _privateKeyRepository.GetMaxId(); 
                }
                catch (Exception e)
                {
                    privateKeyNewId = 1;
                }

                publicKeyNewId++;
                privateKeyNewId++;

                var cert = new Certificate()
                {
                    CertName = certName,
                    PrivateKeyId = privateKeyNewId,
                    PublicKeyId = publicKeyNewId,
                    Actual = true
                };

                await _certificateRepository.Create(cert);

                CryptoKey privateKey = new CryptoKey()
                {
                    Exponent = _privateKey.Exponent,
                    Modulus = _privateKey.Modulus,
                    P = _privateKey.P,
                    Q = _privateKey.Q,
                    DP = _privateKey.DP,
                    DQ = _privateKey.DQ,
                    InverseQ = _privateKey.InverseQ,
                    D = _privateKey.D
                };
                CryptoKey publicKey = new CryptoKey()
                {
                    Exponent = _publicKey.Exponent,
                    Modulus = _publicKey.Modulus
                };

                await _publicKeyRepository.Create(new Models.PublicKey
                {
                    Id = publicKeyNewId,
                    Key = JsonConvert.SerializeObject(publicKey),
                    Actual = true
                });

                await _privateKeyRepository.Create(new PrivateKey
                {
                    Id = privateKeyNewId,
                    Key = JsonConvert.SerializeObject(privateKey),
                    Actual = true
                });


                return new BaseResponse<Certificate>()
                {
                    StatusCode = StatusCode.OK,
                    Data = cert
                };
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"[CryptoService.CreateKey]: {ex.Message}");
                return new BaseResponse<Certificate>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<bool>> VerifySignature(VerifyEmailViewModel model)
        {
            try
            {
                var chooseKey = _certificateRepository.GetAll().Where(x => x.CertName == model.CertName).FirstOrDefault();

                if (chooseKey == null) 
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Сертификата с таким именем не найдено",
                        StatusCode = StatusCode.OK
                    };
                }
                var publicKeyJson = _publicKeyRepository.GetAll().Where(x => x.Id == chooseKey.PublicKeyId && x.Actual).FirstOrDefault();

                CryptoKey publicCryptoKey = JsonConvert.DeserializeObject<CryptoKey>(publicKeyJson.Key);

                var email = _emailRepository.GetAll().Where(x => x.Id == model.EmailId).FirstOrDefault();

                var emailTextBytes = Encoding.Default.GetBytes(email.Data);
                emailTextBytes = SHA256.Create().ComputeHash(emailTextBytes);


                var signature = email.Signature;


                bool decision = Signature.VerifySignature(emailTextBytes, signature, publicCryptoKey);

                if (decision)
                {
                    return new BaseResponse<bool>()
                    {
                        Data = decision,
                        Description = "Сертификат соответствует подписи",
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Сертификат не соответствует подписи",
                        StatusCode = StatusCode.InvalidSignature
                    };
                }

            }
            catch(Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description= $"[VerifySignature] : {ex.Message}",
                    StatusCode = Models.Enum.StatusCode.InternalServerError
                };
            }

        }


        public IBaseResponse<Email> SignEmail(Email email, string certName) 
        {

            var emailBytes = Encoding.Default.GetBytes(email.Data);
            emailBytes = SHA256.Create().ComputeHash(emailBytes);

            var certificate = _certificateRepository.GetAll().Where(x => x.CertName == certName && x.Actual).FirstOrDefault();

            var _privateKey = _privateKeyRepository.GetAll().Where(x => x.Id == certificate.PrivateKeyId && x.Actual).FirstOrDefault();

            CryptoKey privateKey = JsonConvert.DeserializeObject<CryptoKey>(_privateKey.Key);

            var signature = Signature.SignData(emailBytes, privateKey);

            email.Signature = signature;

            return new BaseResponse<Email>()
            {
                Data = email,
                StatusCode = StatusCode.OK
            };
        }
    }
}
