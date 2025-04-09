using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Repositorys;
using Quiron.EntityFrameworkCore.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Repositorys
{
    public class ClassificationRepository(ContextTest contextTest
                                        , ILogger<PersistenceData<ContextTest, Classification>> logger
                                        , IMessagesProvider provider)
        : PersistenceData<ContextTest, Classification>(contextTest, logger, provider), IClassificationRepository { }
}