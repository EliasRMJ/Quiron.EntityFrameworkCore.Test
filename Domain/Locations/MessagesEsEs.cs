using Quiron.EntityFrameworkCore.MessagesProvider;

namespace Quiron.EntityFrameworkCore.Test.Domain.Locations
{
    public class MessagesEsEs: Messages
    {
        public override string Error => "ERROR";
        public override string Warning => "ATENCIÓN";
        public override string Success => "ÉXITO";
        public override string Unknown => "[desconocido]";

        public override string BadRequest => "Se produjo una excepción en la aplicación.";
        public override string NotFound => "No se encontró la clave solicitada.";
        public override string Unauthorized => "Acceso no autorizado.";
        public override string InternalServerError => "Error Interno del Servidor. Por favor, inténtelo de nuevo más tarde.";
        public override string UnexpectedOccurred => "Se produjo un error inesperado.";

        public override string EntityNull => "La entidad es nula";
        public override string RegisterSuccess => "Registro completado exitosamente!";
        public override string UpdateSuccess => "Actualización completada exitosamente!";
        public override string DeleteSuccess => "Eliminación realizada con éxito!";
        public override string AddSuccess => "Añadido exitosamente!";
        public override string IncludeProblem => "Ups, algo salió mal al incluir la entidad!";
        public override string UpdateProblem => "¡Ups! ¡Algo salió mal al actualizar la entidad!";
        public override string DeleteProblem => "¡Ups! ¡Algo salió mal al eliminar la entidad!";
        public override string UnexpectedError => "Se produjo un error inesperado al eliminar la entidad";
        public override string CheckProperty => "Comprueba si la propiedad es una primera clave o una clave externa.";
        public override string PropertyRequired => "obligatorio, pero no hay ningún mensaje configurado en la entidad!";
        public override string EntityFound => "¡Entidad no encontrada!";

        public override string EntityConversion => "Iniciar la conversión de objeto a entidad en el método";
        public override string StartCallMethod => "Conversión del objeto a la entidad ejecutada con éxito en el método";

        public override string NoResultList => "¡No se encontraron registros en este momento con los filtros proporcionados!";
        public override string NoResult => "¡No se encontraron registros!";

        public override string FilterMethod => "Iniciando el método de filtros en";
        public override string ConvertMethodFilter => "La conversión de entidad a objeto se ejecutó exitosamente en el método de filtro.";

        public override string TransactionErrorUnexpected => "Error inesperado al completar la transacción";
        public override string TransactionError => "¡Error al iniciar la transacción!";
        public override string TransactionNoStarting => "'CommitAsync' requiere una transacción activa. ¡Intente iniciar el método 'BeginTransactionAsync' primero!";

        public override string MailExcept => "Error al enviar el correo electrónico.";
        public override string MailArgumentNullExceptiont => "Error de argumento nulo.";
        public override string MailObjectDisposedException => "Error al desechar el objeto.";
        public override string MailServiceNotConnectedException => "Error de servicio no conectado.";
        public override string MailServiceNotAuthenticatedException => "Error en la autenticación del servicio.";
        public override string MailInvalidOperationException => "La operación no es válida.";
        public override string MailOperationCanceledException => "Se produjo una excepción al cancelar la operación.";
        public override string MailCommandException => "El comando puede no ser válido.";
        public override string MailProtocolException => "El protocolo de correo electrónico no es inválido.";
    }
}