using AutoMapper;
using Quiron.EntityFrameworkCore.AppServices;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Services;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.AppServices
{
    public class ClassificationAppService(IClassificationService classificationService
                                        , ITransactionWork transactionWork
                                        , IMapper mapper
                                        , ILogger<ClassificationViewModel> logger
                                        , IMessagesProvider provider)
        : AppServiceBase<ClassificationViewModel, Classification>(classificationService, transactionWork, mapper, logger, provider)
        , IClassificationAppService { }
}