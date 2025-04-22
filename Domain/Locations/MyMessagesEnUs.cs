using Quiron.EntityFrameworkCore.MessagesProvider.Locations;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Locations
{
    public class MyMessagesEnUs : MessagesEnUs, IMyMessages
    {
        public string RegisterNotFound => "Register isn't found";
        public string ExceptionUpdate => "An unexpected error occurred while updating the provider";
        public string InvalidOperation => "Invalid operation!";
    }
}