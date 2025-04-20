using AutoMapper;
using Quiron.EntityFrameworkCore.AppServices;
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Structs;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.AppServices
{
    public class ClassificationAppService(IClassificationService classificationService
                                        , ITransactionWork transactionWork
                                        , IMapper mapper
                                        , ILogger<ClassificationViewModel> logger
                                        , IMyMessagesProvider provider)
        : AppServiceBase<ClassificationViewModel, Classification>(classificationService, transactionWork, mapper, logger, provider)
        , IClassificationAppService
    {
        public async Task<OperationReturn> ChangeStatusAsync(long id, ActiveEnum status)
        {
            var classification = await classificationService.GetEntityTrackingByIdAsync(id);
            if (classification == null)
            {
                return new()
                {
                    ReturnType = ReturnTypeEnum.Empty,
                    EntityName = "Classification",
                    Field = "Id",
                    Key = $"{id}",
                    Messages = [new() { Code = "-1", ReturnType = ReturnTypeEnum.Empty, Text = provider.Current.EntityFound }]
                };
            }

            classification.Active = status;
            return await classificationService.UpdateAsync(classification);
        }
    }
}