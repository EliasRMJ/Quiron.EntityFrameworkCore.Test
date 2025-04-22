using Quiron.EntityFrameworkCore.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces
{
    public interface IMyMessages : IMessages
    {
        string RegisterNotFound { get; }
        string ExceptionUpdate { get; }
        string InvalidOperation{ get; }
    }
}