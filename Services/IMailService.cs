using COSMIDENT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COSMIDENT.Services
{
    public interface IMailService
    {
        void SendEmail(MailRequest mailRequest);
        string CreateEmailBody(List<Unit> units);
    }
}
