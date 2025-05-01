using MimeKit;
using Quiron.Mail;

namespace Quiron.EntityFrameworkCore.Test.Domain.MailSend
{
    public class ServerMailTest(IConfiguration configuration) 
        : ServerEmail(configuration)
    {
        public async override Task SendMailAsync(ParamEmail from, ParamEmail to, string subject, string message, MailAttachment[] mailAttachments
            , MessagePriority messagePriority = MessagePriority.Normal)
        {
            await base.SendMailAsync(from, [new MailboxAddress(to.Name, to.Email)], subject, message, mailAttachments, messagePriority);
        }

        public async override Task SendMailAsync(ParamEmail from, InternetAddressList mailboxAddresses, string subject, string message
            , MailAttachment[] mailAttachments, MessagePriority messagePriority = MessagePriority.Normal)
        {
            await base.SendMailAsync(from, mailboxAddresses, subject, message, mailAttachments, messagePriority);
        }
    }
}