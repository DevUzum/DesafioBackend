using DesafioBackend.Controllers.Clientes.Cadastro;
using DesafioBackend.DI;
using FluentValidation.AspNetCore;

namespace DesafioBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureService(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CadastroClienteRequestDto>());
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.DBServiceCollectionExtension();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
