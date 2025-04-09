using AutoMapper;
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.Mapper
{
    public class CustomPersonResolver : IValueResolver<ClientViewModel, Client, Person>
    {
        public Person Resolve(ClientViewModel source, Client destination, Person destMember, ResolutionContext context)
        {
            var emails = source.Emails?.Select(email => new EmailPerson
            {
                Id = email.Id,
                Mail = email.Mail,
                PersonId = source.ClientId
            }).ToList();

            if (source.PersonType == PersonTypeEnum.Legal)
            {
                return new LegalPerson
                {
                    Id = source.ClientId,
                    Name = source.Name,
                    ComplementName = source.ComplementName,
                    InclusionDate = source.InclusionDate,
                    PersonType = source.PersonType,
                    Active = source.Active,
                    DocumentNumber = source.DocumentNumber,
                    MunicipalRegistration = source.MunicipalRegistration,
                    Emails = emails
                };
            }
            else
            {
                return new PhysicsPerson
                {
                    Id = source.ClientId,
                    Name = source.Name,
                    ComplementName = source.ComplementName,
                    InclusionDate = source.InclusionDate,
                    PersonType = source.PersonType,
                    Active = source.Active,
                    DocumentNumber = source.DocumentNumber,
                    DateBirth = source.DateBirth,
                    Emails = emails
                };
            }
        }
    }
}