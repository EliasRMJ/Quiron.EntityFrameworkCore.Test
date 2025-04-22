using Quiron.EntityFrameworkCore.MessagesProvider.Locations;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Locations
{
    public class MyMessagesPtBr : MessagesPtBr, IMyMessages
    {
        public string RegisterNotFound => "Registro não encontrado";
        public string ExceptionUpdate => "Ocorreu um erro inesperado ao atualizar o provedor";
        public string InvalidOperation => "Operação inválida!";
    }
}