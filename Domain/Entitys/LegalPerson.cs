using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Quiron.EntityFrameworkCore.Test.Domain.Entitys
{
    [DebuggerDisplay("{DocumentNumber}")]
    [DisplayName("Legal Person")]
    [Table("LegalPerson")]
    public class LegalPerson : Person
    {
        [Required(ErrorMessage = "The document number of the legal entity is required!")]
        [MaxLength(18, ErrorMessage = "The document number of the legal entity cannot contain more than 18 information!")]
        [Column("DocumentNumber")]
        public string? DocumentNumber { get; set; }

        [MaxLength(20, ErrorMessage = "The municipal registration of the legal entity cannot contain more than 20 information!")]
        [Column("MunicipalRegistration")]
        public string? MunicipalRegistration { get; set; }
    }
}