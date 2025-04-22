using Quiron.EntityFrameworkCore.Services;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Repositorys;
using Quiron.EntityFrameworkCore.Test.Domain.Validations.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Services
{
    public class ClassificationService(IClassificationRepository repository
                                     , IClassificationValidation validation
                                     , IMyMessagesProvider provider)
        : ServiceBase<Classification>(repository, validation, provider), IClassificationService { }
}