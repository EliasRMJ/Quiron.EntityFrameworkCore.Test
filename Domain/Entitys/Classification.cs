using Quiron.EntityFrameworkCore.Entitys;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace Quiron.EntityFrameworkCore.Test.Domain.Entitys
{
    [DebuggerDisplay("{Name}")]
    [DisplayName("Classification")]
    [Table("Classification")]
    public class Classification : EntityTypeBase { }
}