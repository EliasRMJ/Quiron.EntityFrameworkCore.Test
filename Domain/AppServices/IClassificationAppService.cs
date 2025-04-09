using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.AppServices
{
    public interface IClassificationAppService : IAppServiceBase<ClassificationViewModel>
    { }
}