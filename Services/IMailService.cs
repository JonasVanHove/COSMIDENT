using COSMIDENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT.Services
{
    interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
