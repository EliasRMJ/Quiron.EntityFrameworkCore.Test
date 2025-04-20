using AutoMapper;
using Quiron.EntityFrameworkCore.AppServices;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.AppServices
{
    public class ClientAppService(IClientService clientService
                                , ITransactionWork transactionWork
                                , IMapper mapper
                                , ILogger<ClientViewModel> logger
                                , IMyMessagesProvider provider)
        : AppServiceBase<ClientViewModel, Client>(clientService, transactionWork, mapper, logger, provider), IClientAppService { }
}