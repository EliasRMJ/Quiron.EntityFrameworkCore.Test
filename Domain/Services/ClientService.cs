using Quiron.EntityFrameworkCore.Services;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Repositorys;

namespace Quiron.EntityFrameworkCore.Test.Domain.Services
{
    public class ClientService(IClientRepository repository, IMyMessagesProvider provider)
        : ServiceBase<Client>(repository, provider), IClientService { }
}