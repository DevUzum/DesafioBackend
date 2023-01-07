using DesafioBackend.Controllers.Clientes.Cadastro;
using DesafioBackend.Interfaces;
using DesafioBackend.Repositories;
using DesafioBackend.Services.Clientes.Cadastro;

namespace DesafioBackend.DI
{
    public static class DBServiceCollectionExtensions
    {
        public static void DBServiceCollectionExtension(this IServiceCollection serviceDescriptors)
        {
            AddRepositories(serviceDescriptors);
        }

        private static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped(x =>
                new CadastroClienteController(
                    x.GetService<ICadastroClienteService>()));

            service.AddScoped<ICadastroClienteService>(x =>
                new CadastroClienteService(
                    x.GetService<IClienteRepository>()));

            service.AddScoped<IClienteRepository>(p =>
                new ClienteRepository(
                    p.GetRequiredService<Context.DesafioBackendContext>()));

        }
    }
}
