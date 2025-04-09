using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Transactions;

namespace Quiron.EntityFrameworkCore.Test.Domain.Transaction
{
    public class TransactionWork(ContextTest context, IMessagesProvider provider)
        : TransactionWorkBase(context, provider) { }
}