using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Repositorys;
using Microsoft.EntityFrameworkCore;
using Quiron.EntityFrameworkCore.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Repositorys
{
    public class ClientRepository(ContextTest contextTest
                                , ILogger<PersistenceData<ContextTest, Client>> logger
                                , IMessagesProvider provider)
        : PersistenceData<ContextTest, Client>(contextTest, logger, provider), IClientRepository
    {
        public override async Task EntityHierarchy(Client element)
        {
            await base.EntityHierarchy(element);

            if (element.ElementStates == Enuns.ElementStatesEnum.New) contextTest.Clients.Add(element);
            else if (element.ElementStates == Enuns.ElementStatesEnum.Update) contextTest.Clients.Update(element);
        }

        public override async Task<Client> GetEntityByIdAsync(long id)
        {
            return await contextTest.Clients
                .AsNoTrackingWithIdentityResolution()
                .Include(inc => inc.Person)
                .Include(inc => inc.Classification)
                .Include(inc => inc.Person.Emails)
                .FirstOrDefaultAsync(find => find.ClientId == id);
        }
    }
}