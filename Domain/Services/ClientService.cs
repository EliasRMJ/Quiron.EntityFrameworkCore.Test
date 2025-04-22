using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Services;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Repositorys;
using Quiron.EntityFrameworkCore.Test.Domain.Validations.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Services
{
    public class ClientService(IClientRepository repository
                             , IClientValidation validation
                             , IMessagesProvider provider)
        : ServiceBase<Client>(repository, validation, provider), IClientService { }
}