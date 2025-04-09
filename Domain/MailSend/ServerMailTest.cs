using Microsoft.Extensions.Configuration;
using MimeKit;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Mail;
using Quiron.EntityFrameworkCore.Structs;

namespace Quiron.EntityFrameworkCore.Test.Domain.MailSend
{
    public class ServerMailTest(IConfiguration configuration, IMessagesProvider provider) 
        : ServerEmail(configuration, provider)
    {
        public override Task SendMailAsync(string from, InternetAddressList mailboxAddresses, string subject
            , string message, MailAttachment[] mailAttachments, bool userSsl = false, MessagePriority messagePriority = MessagePriority.Normal)
        {
            return base.SendMailAsync(from, mailboxAddresses, subject, message, mailAttachments, userSsl, messagePriority);
        }

        public override Task SendMailAsync(string from, string to, string toName, string subject, string message
            , MailAttachment[] mailAttachments, bool userSsl = false, MessagePriority messagePriority = MessagePriority.Normal)
        {
            return base.SendMailAsync(from, to, toName, subject, message, mailAttachments, userSsl, messagePriority);
        }
    }
}