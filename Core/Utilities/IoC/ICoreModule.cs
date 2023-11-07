using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
        //genel bağımlılıkları yükleyecek
        void Load(IServiceCollection serviceCollection);
    }
}
