using Quiron.EntityFrameworkCore.Entitys;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Quiron.EntityFrameworkCore.Test.Domain.Entitys
{
    [DebuggerDisplay("{Person.Name}")]
    [DisplayName("Client")]
    [Table("Client")]
    public class Client: EntityBase
    {
        [NotMapped] public override long Id { get => base.Id; set => base.Id = value; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column("ClientId")]
        public long ClientId { get; set; }

        [MaxLength(2000, ErrorMessage = "Note cannot contain more than 2000 carecteres!")]
        [Column("Note")]
        public string? Note { get; set; }

        [Column("ClassificationId")]
        public long? ClassificationId { get; set; }

        [ForeignKey("ClientId")]
        public virtual required Person Person { get; set; }

        [ForeignKey("ClassificationId")]
        public virtual Classification? Classification { get; set; }
    }
}