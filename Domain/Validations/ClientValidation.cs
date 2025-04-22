using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.Validations.Interfaces;
using Quiron.EntityFrameworkCore.Validations;

namespace Quiron.EntityFrameworkCore.Test.Domain.Validations
{
    public class ClientValidation(IMyMessagesProvider messagesProvider)
        : ValidationBase<Client>(messagesProvider), IClientValidation
    {
        public override async Task Validate(IElement element)
        {
            await base.Validate(element);

            if (this.IsValid)
            {
                var client = element as Client;

            }
        }
    }
}