using COSMIDENT.Interfaces;
using COSMIDENT.Models;
using COSMIDENT.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace COSMIDENT.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly ISupplier _supplierRepository;

        public MailService (IOptions<MailSettings> options, ISupplier supplierRepository)
        {
            _mailSettings = options.Value;
            _supplierRepository = supplierRepository;
        }
        public void SendEmail(MailRequest mailrequest)
        {
            MailMessage mailMessage = new MailMessage()
            {
                Subject = mailrequest.Subject,
                Body = mailrequest.Body,
                IsBodyHtml = true,
                From = new MailAddress(_mailSettings.Mail),
            };

            mailMessage.To.Add(mailrequest.ToEmail);

            var smtpClient = new SmtpClient(_mailSettings.Host)
            {
                UseDefaultCredentials = false,
                Port = _mailSettings.Port,
                Credentials = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            smtpClient.Send(mailMessage);
        }

        public string CreateEmailBody(List<Unit> units)
        {
            var unitList = "";

            foreach (var unit in units)
            {
                var supplier = _supplierRepository.GetSupplier(unit.SupplierID);
                unitList += $"<tr>" +
                $"<td>{unit.Name}</td>" +
                $"<td>{unit.Description}</td>" +
                $"<td>{supplier.SupplierName}</td>" +
                $"<td>{supplier.Email}</td>" +
                $"<td>{supplier.MobilePhone}</td>" +
                $"</tr>";
            }

            return "<!DOCTYPE html>" +
            "<html lang = 'nl'>" +
            "<head>" +
            "<meta charset = 'UTF-8'>" +
            "<title> Mail </title>" +
            "</head>" +
            "<body>" +
            "<h2> Stockbeheer Cosmident </h2>" +
            "<p> Beste<br> <br>" +
            "Onderstaande stock is onder het gewenste niveau gegaan:" +
            "</p>" +
            "<table>" +
            "<tr>" +
            "<th> Product </th>" +
            "<th> Barcode </th>" +
            "<th> Leverancier </th>" +
            "<th> Leveranciermail </th>" +
            "<th> Leveranciertelefoon </th>" +
            "</tr>" +
            unitList +
            "</table>" +
            "<p>Met vriendelijke groeten<br><br>" +
            "Team Stockbeheer Cosmident</p>" +
            "</body>" +
            "</html> ";
        }
    }
}
