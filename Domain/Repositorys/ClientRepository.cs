using Microsoft.EntityFrameworkCore;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Repositorys;
using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Extensions;
using Quiron.EntityFrameworkCore.Structs;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Repositorys
{
    public class ClientRepository(ContextTest contextTest
                                , ILogger<PersistenceData<ContextTest, Client>> logger
                                , ITransactionWork unitwork
                                , IMyMessagesProvider provider)
        : PersistenceData<ContextTest, Client>(contextTest, logger, provider), IClientRepository
    {
        public async override Task EntityHierarchy(Client element)
        {
            await base.EntityHierarchy(element);

            if (element.ElementStates == ElementStatesEnum.New) contextTest.Clients.Add(element);
            else if (element.ElementStates == ElementStatesEnum.Update) contextTest.Clients.Update(element);
        }

        public async override Task<OperationReturn> UpdateAsync(Client element)
        {
            var _returnUpdate = new OperationReturn { EntityName = "Client", ReturnType = ReturnTypeEnum.Empty, Field = "Id", Key = $"{element.ClientId}" };

            var client = await GetEntityByIdAsync(element.Id);
            if (client is null)
            {
                _returnUpdate.Messages.Add(new() { Text = provider.Current.EntityFound, ReturnType = ReturnTypeEnum.Empty });
                return _returnUpdate;
            }

            try
            {
                await unitwork.BeginTransactionAsync();

                if (client.Person.Emails?.Count > 0 && element.Person.Emails?.Count > 0)
                {
                    var atualizarcontextTesto = false;
                    foreach (var emailRemove in client.Person.Emails)
                    {
                        if (!element.Person.Emails.Any(f => f.Mail == emailRemove.Mail))
                        {
                            contextTest.EmailPersons.Remove(emailRemove);
                            atualizarcontextTesto = true;
                        }
                    }

                    if (atualizarcontextTesto)
                        await contextTest.SaveChangesAsync();
                }
                else if (client.Person.Emails?.Count > 0 && element.Person.Emails?.Count == 0)
                {
                    contextTest.EmailPersons.RemoveRange(client.Person.Emails);
                    await contextTest.SaveChangesAsync();
                }

                if (element.Person.Emails?.Count > 0)
                {
                    foreach (var email in element.Person.Emails)
                    {
                        if (email.Id > 0)
                            contextTest.EmailPersons.Update(email);
                    }
                }

                _returnUpdate = await base.UpdateAsync(element);

                if (_returnUpdate.IsSuccess) await unitwork.CommitAsync();
                else await unitwork.RollbackAsync();
            }
            catch (Exception ex)
            {
                await unitwork.RollbackAsync();

                _returnUpdate.ReturnType = ReturnTypeEnum.Error;
                _returnUpdate.Messages.Add(new()
                {
                    Text = $"{provider.MyCurrent.ExceptionUpdate} '{element.Person.Name}'. {provider.Current.Error}: {ex.AggregateMessage()}",
                    ReturnType = ReturnTypeEnum.Error,
                    Code = provider.Current.Error
                });
            }

            return _returnUpdate;
        }

        public async override Task<Client> GetEntityByIdAsync(long id)
        {
            return await contextTest.Clients
                .AsNoTrackingWithIdentityResolution()
                .Include(inc => inc.Classification)
                .Include(inc => inc.Person.Emails)
                .FirstOrDefaultAsync(find => find.ClientId == id);
        }
    }
}