using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Structs;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.AppServices
{
    public interface IClassificationAppService : IAppServiceBase<ClassificationViewModel>
    { 
        Task<OperationReturn> ChangeStatusAsync(long id, ActiveEnum status);
    }
}