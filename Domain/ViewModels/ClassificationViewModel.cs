using Quiron.EntityFrameworkCore.Enuns;

namespace Quiron.EntityFrameworkCore.Test.Domain.ViewModels
{
    public class ClassificationViewModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public ActiveEnum Active { get; set; }
    }
}