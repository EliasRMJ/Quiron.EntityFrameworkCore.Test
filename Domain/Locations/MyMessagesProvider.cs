using Quiron.EntityFrameworkCore.MessagesProvider;
using Quiron.EntityFrameworkCore.MessagesProvider.Locations;

namespace Quiron.EntityFrameworkCore.Test.Domain.Locations
{
    public class MyMessagesProvider(IHttpContextAccessor httpContextAccessor
                                  , IServiceProvider serviceProvider) 
        : MessagesProvider.MessagesProvider(httpContextAccessor, serviceProvider)
    {
        public override Messages Current
        {
            get
            {
                var culture = GetRequestCulture();

                return culture switch
                {
                    "en-US" => serviceProvider.GetRequiredService<MessagesEnUs>(),
                    "pt-BR" => serviceProvider.GetRequiredService<MessagesPtBr>(),
                    "es-ES" => serviceProvider.GetRequiredService<MessagesEsEs>(),
                    _ => serviceProvider.GetRequiredService<Messages>()
                };
            }
        }
    }
}