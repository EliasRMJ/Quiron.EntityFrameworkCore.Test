using AutoMapper;
using Quiron.EntityFrameworkCore.Enuns;
using Quiron.EntityFrameworkCore.Test.Domain.Entitys;
using Quiron.EntityFrameworkCore.Test.Domain.ViewModels;

namespace Quiron.EntityFrameworkCore.Test.Domain.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Classification, ClassificationViewModel>();
            CreateMap<ClassificationViewModel, Classification>();

            CreateMap<Client, ClientViewModel>()
                .ForMember(d => d.ClientId, opt => opt.MapFrom(src => src.Person.Id))
                .ForMember(d => d.ClassificationId, opt => opt.MapFrom(src => src.ClassificationId))
                .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(d => d.ComplementName, opt => opt.MapFrom(src => src.Person.ComplementName))
                .ForMember(d => d.InclusionDate, opt => opt.MapFrom(src => src.Person.InclusionDate))
                .ForMember(d => d.PersonType, opt => opt.MapFrom(src => src.Person.PersonType))
                .ForMember(d => d.Active, opt => opt.MapFrom(src => src.Person.Active))
                .ForMember(d => d.Note, opt => opt.MapFrom(src => src.Note))
                .ForMember(d => d.DocumentNumber, opt => opt.MapFrom(src => src.Person.PersonType == PersonTypeEnum.Phisic ? ((PhysicsPerson)src.Person).DocumentNumber : ((LegalPerson)src.Person).DocumentNumber))
                .ForMember(d => d.MunicipalRegistration, opt => opt.MapFrom(src => src.Person.PersonType == PersonTypeEnum.Phisic ? null : ((LegalPerson)src.Person).MunicipalRegistration))
                .ForMember(d => d.DateBirth, opt => opt.MapFrom(src => src.Person.PersonType == PersonTypeEnum.Phisic ? ((PhysicsPerson)src.Person).DateBirth : null))
                .ForMember(d => d.Classification, opt => opt.MapFrom(src => src.Classification))
                .ForMember(d => d.Emails, opt => opt.MapFrom(src => src.Person.Emails));

            CreateMap<ClientViewModel, Client>()
                .ForMember(d => d.Person, opt => opt.MapFrom<CustomPersonResolver>());

            CreateMap<EmailViewModel, EmailPerson>();
            CreateMap<EmailPerson, EmailViewModel>();
        }
    }
}