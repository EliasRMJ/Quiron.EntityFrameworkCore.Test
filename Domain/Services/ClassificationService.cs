using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Services;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.Repositorys;

namespace Quiron.EntityFrameworkCore.Test.Domain.Services
{
    public class ClassificationService(IClassificationRepository repository, IMessagesProvider provider)
        : ServiceBase<Classification>(repository, provider), IClassificationService
    { }
}