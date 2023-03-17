using Arch_lab.Models;
using Arch_lab.Models.ViewModel;
using Arch_lab.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Arch_lab.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ICryptoService _cryptoService;

        public EmailController(IEmailService emailService, ICryptoService cryptoService)
        {
            _emailService = emailService;
            _cryptoService = cryptoService;
        }

        public IActionResult Index(string userName)
        {
            ViewBag.UserName = userName;
            ViewBag.certs = _cryptoService.GetCerts().Data; 
            var response = _emailService.GetEmails().Data;
            if (response != null)
            {
                return View(response.ToList().Where(x => x.Receiver == userName).ToList());
            } 
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmail(CreateEmailViewModel model)
        {
            var response = await _emailService.Create(model);

            if (response.StatusCode == Models.Enum.StatusCode.OK)
            {
                return Ok(new {description = response.Description});

            }
            return BadRequest(new { description = response.Description });

        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {

            var response = await _cryptoService.VerifySignature(model);

            if (response.StatusCode == Models.Enum.StatusCode.OK)
            {
                return Ok(new { description = response.Description });

            }
            return BadRequest(new { description = response.Description });

        }

        [HttpPost]
        public async Task<IActionResult> CreateCert(CreateCertViewModel model)
        {
            var response = await _cryptoService.CreateKey(model.CertName);

            if (response.StatusCode == Models.Enum.StatusCode.OK)
            {
                return Ok(new { description = response.Description });

            }
            return BadRequest(new { description = response.Description });

        }
    }
}