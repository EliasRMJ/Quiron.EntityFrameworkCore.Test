using Quiron.EntityFrameworkCore.Entitys;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Quiron.EntityFrameworkCore.Test.Domain.Entitys
{
    [DebuggerDisplay("{Mail}")]
    [DisplayName("Email Person")]
    [Table("EmailPerson")]
    public class EmailPerson : EntityBase
    {
        [Required(ErrorMessage = "Enter the description of the email!")]
        [MaxLength(70, ErrorMessage = "Email cannot contain more than 70 characters!")]
        [Column("Mail")]
        public string? Mail { get; set; }

        [Required(ErrorMessage = "The person is obligatory!")]
        [Range(1, long.MaxValue, ErrorMessage = "The person's id must be greater than ZERO.")]
        [Column("PersonId")]
        public long PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person? Person { get; set; }
    }
}