using AutoMapper;
using Quiron.EntityFrameworkCore.AppServices;
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Structs;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;
using Quiron.EntityFrameworkCore.Utils;
using System.Linq.Expressions;

namespace Quiron.EntityFrameworkCore.Test.Domain.AppServices
{
    public class ClientAppService(IClientService clientService
                                , ITransactionWork transactionWork
                                , IMapper mapper
                                , ILogger<ClientViewModel> logger
                                , IMessagesProvider provider)
        : AppServiceBase<ClientViewModel, Client>(clientService, transactionWork, mapper, logger, provider), IClientAppService
    {
        public override async Task<OperationReturn> UpdateAsync(ClientViewModel element)
        {
            var clientExist = await clientService.GetEntityByIdAsync(element.ClientId);
            if (clientExist is null)
            {
                var operationResult = new OperationReturn
                {
                    EntityName = "Client",
                    Field = "ClientId",
                    Key = element.ClientId.ToString(),
                    ReturnType = ReturnTypeEnum.Empty,
                    Messages = [ new() { Code = provider.Current.Warning, Text = $"Client {element.ClientId} not found!" } ]
                };
                return operationResult;
            }

            return await base.UpdateAsync(element);
        }

        public override async Task<IEnumerable<ClientViewModel>> Filter(Expression<Func<ClientViewModel, bool>> filter
            , int pageNumber, int pageSize)
        {
            logger.LogInformation($"{provider.Current.FilterMethod} 'ClientAppService'.");
            var filterConvert = ExpressionFuncConvert.Builder<ClientViewModel, Client>(filter, "Person");
            var resultList = await clientService.Filter(filterConvert, pageNumber, pageSize
                                                      , inc => inc.Person
                                                      , inc => inc.Classification
                                                      , inc => inc.Person.Emails);

            if (resultList is null || !resultList.Any())
            {
                logger.LogWarning(provider.Current.NoResultList);
                throw new Exception(provider.Current.NoResultList);
            }

            logger.LogInformation(provider.Current.ConvertMethodFilter);
            return mapper.Map<IEnumerable<ClientViewModel>>(resultList);
        }
    }
}