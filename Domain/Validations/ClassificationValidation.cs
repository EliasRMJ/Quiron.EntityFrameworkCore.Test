using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.Validations.Interfaces;
using Quiron.EntityFrameworkCore.Validations;

namespace Quiron.EntityFrameworkCore.Test.Domain.Validations
{
    public class ClassificationValidation(IClientService clientService
                                        , IMyMessagesProvider messagesProvider)
        : ValidationBase<Classification>(messagesProvider), IClassificationValidation
    {
        public override async Task Validate(IElement element)
        {
            await base.Validate(element);

            if (this.IsValid)
            {
                var classification = element as Classification;

                if (classification!.Active == Enuns.ActiveEnum.N)
                {
                    var clients = await clientService.Filter(find => find.ClassificationId == classification.Id);
                    if (clients.Any())
                        _messages.Add(messagesProvider.MyCurrent.InvalidOperation);
                }
            }
        }
    }
}