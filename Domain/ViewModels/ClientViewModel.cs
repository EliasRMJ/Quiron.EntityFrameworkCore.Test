using Quiron.EntityFrameworkCore.Enuns;

namespace Quiron.EntityFrameworkCore.Test.Domain.ViewModels
{
    public class ClientViewModel
    {
        public long ClientId { get; set; }
        public long? ClassificationId { get; set; }
        public string? Name { get; set; }
        public string? ComplementName { get; set; }
        public string? DocumentNumber { get; set; }
        public string? MunicipalRegistration { get; set; }
        public string? Note { get; set; }
        public DateTime InclusionDate { get; set; }
        public DateOnly? DateBirth { get; set; }
        public PersonTypeEnum PersonType { get; set; }
        public ActiveEnum Active { get; set; }
        public ClassificationViewModel? Classification { get; set; }
        public List<EmailViewModel>? Emails { get; set; }
    }
}