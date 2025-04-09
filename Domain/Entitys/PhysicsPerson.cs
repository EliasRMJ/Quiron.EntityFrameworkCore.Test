using Quiron.EntityFrameworkCore.Entitys;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Quiron.EntityFrameworkCore.Test.Domain.Entitys
{
    [DebuggerDisplay("{DocumentNumber}")]
    [DisplayName("Physics Person")]
    [Table("PhysicsPerson")]
    public class PhysicsPerson : Person
    {
        [Required(ErrorMessage = "The document number of the physics person is required!")]
        [MaxLength(14, ErrorMessage = "The individual's document number cannot contain more than 14 characters!")]
        [Column("DocumentNumber")]
        public string? DocumentNumber { get; set; }

        [Column("DateBirth")]
        public DateOnly? DateBirth { get; set; }
    }
}