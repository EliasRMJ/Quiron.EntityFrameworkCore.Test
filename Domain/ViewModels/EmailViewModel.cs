using Quiron.EntityFrameworkCore.Enuns;

namespace Quiron.EntityFrameworkCore.Test.Domain.ViewModels
{
    public class EmailViewModel
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string? Mail { get; set; }
    }
}