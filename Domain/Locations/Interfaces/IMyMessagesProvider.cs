using Quiron.EntityFrameworkCore.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces
{
    public interface IMyMessagesProvider : IMessagesProvider 
    {
        IMyMessages MyCurrent { get; }
    }
}