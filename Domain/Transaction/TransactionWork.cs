using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;
using Quiron.EntityFrameworkCore.Transactions;

namespace Quiron.EntityFrameworkCore.Test.Domain.Transaction
{
    public class TransactionWork(ContextTest context, IMyMessagesProvider provider)
        : TransactionWorkBase(context, provider) { }
}