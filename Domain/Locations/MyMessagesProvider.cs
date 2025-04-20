using Quiron.EntityFrameworkCore.Interfaces;
using Quiron.EntityFrameworkCore.Test.Domain.Locations.Interfaces;

namespace Quiron.EntityFrameworkCore.Test.Domain.Locations
{
    public class MyMessagesProvider(IHttpContextAccessor httpContextAccessor
                                  , IServiceProvider serviceProvider) 
        : MessagesProvider.MessagesProvider(httpContextAccessor, serviceProvider), IMyMessagesProvider
    {
        public override IMessages Current
        {
            get
            {
                var culture = GetRequestCulture();

                return culture switch
                {
                    "en-US" => serviceProvider.GetRequiredService<MyMessagesEnUs>(),
                    "pt-BR" => serviceProvider.GetRequiredService<MyMessagesPtBr>(),
                    "es-ES" => serviceProvider.GetRequiredService<MessagesEsEs>(),
                    _ => serviceProvider.GetRequiredService<MyMessagesEnUs>()
                };
            }
        }

        public IMyMessages MyCurrent => (IMyMessages)this.Current;
    }
}