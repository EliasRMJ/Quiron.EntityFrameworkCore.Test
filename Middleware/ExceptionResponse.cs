using System.Net;

namespace Quiron.EntityFrameworkCore.Test.Middleware
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}