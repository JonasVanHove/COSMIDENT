using COSMIDENT.Models;
using COSMIDENT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
            private readonly IMailService _mailService;
            private EmailController(IMailService mailService)
            {
                _mailService = mailService;
            }

            [HttpPost("Send")]
            public async Task<IActionResult> Send([FromForm] MailRequest request)
            {
                try
                {
                    await _mailService.SendEmailAsync(request);
                    return Ok();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
    }
}
