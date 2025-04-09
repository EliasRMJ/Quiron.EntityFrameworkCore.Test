using Quiron.EntityFrameworkCore.Entitys;
using Quiron.EntityFrameworkCore.Enuns;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Quiron.EntityFrameworkCore.Test.Domain.Entitys
{
    [DebuggerDisplay("{Name}")]
    [DisplayName("Person")]
    [Table("Person")]
    public class Person : EntityTypeBase 
    {
        [Required(ErrorMessage = "Enter the complement of the person's name!")]
        [MaxLength(50, ErrorMessage = "The complement of the person's name cannot contain more than 50 characters!")]
        [Column("ComplementName")]
        public string? ComplementName { get; set; }

        [Required(ErrorMessage = "The date of inclusion in the registration is mandatory!")]
        [Column("InclusionDate")]
        public DateTime InclusionDate { get; set; }

        [Required(ErrorMessage = "Enter the type of person!")]
        [Column("PersonType")]
        public PersonTypeEnum PersonType { get; set; }

        public virtual ICollection<EmailPerson>? Emails { get; set; }
    }
}