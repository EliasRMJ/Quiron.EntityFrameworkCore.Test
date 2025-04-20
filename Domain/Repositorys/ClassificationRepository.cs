using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Repositorys;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Repositorys
{
    public class ClassificationRepository(ContextTest contextTest
                                        , ILogger<PersistenceData<ContextTest, Classification>> logger
                                        , IMyMessagesProvider provider)
        : PersistenceData<ContextTest, Classification>(contextTest, logger, provider), IClassificationRepository { }
}