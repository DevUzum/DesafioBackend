using DesafioBackend.Client.AwesomeApi;
using DesafioBackend.Controllers.Clientes.Cadastro;
using DesafioBackend.Controllers.Cotacoes.ObterCotacaoDolarComValor;
using DesafioBackend.Cotacoes.ObterCotacaoDolar;
using DesafioBackend.Interfaces;
using DesafioBackend.Repositories;
using DesafioBackend.Services.Clientes.Cadastro;
using DesafioBackend.Services.Cotacoes.ObterCotacaoDolarComValor;

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
            //Cliente
            service.AddScoped(x =>
                new CadastroClienteController(
                    x.GetService<ICadastroClienteService>()));

            service.AddScoped<ICadastroClienteService>(x =>
                new CadastroClienteService(
                    x.GetService<IClienteRepository>()));

            service.AddScoped<IClienteRepository>(p =>
                new ClienteRepository(
                    p.GetRequiredService<Context.DesafioBackendContext>()));

            //Cotacao
            service.AddScoped(x =>
                new ObterCotacaoDolarController(
                     x.GetService<ICotacaoMoedaClient>(),
                     x.GetService<IClienteRepository>()));

            service.AddScoped<ICotacaoMoedaClient>(p =>
                new CotacaoMoedaClient());

            service.AddScoped(x =>
                new ObterCotacaoDolarComValorController(
                     x.GetService<IObterCotacaoDolarComValorService>()));

            service.AddScoped<IObterCotacaoDolarComValorService>(x =>
                new ObterCotacaoDolarComValorService(
                    x.GetService<ICotacaoMoedaClient>(),
                    x.GetService<IClienteRepository>()));

        }
    }
}
