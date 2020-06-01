using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Projeto.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region Swagger

            //configurando a documentação da API gerada pelo Swagger
            services.AddSwaggerGen(s =>
                {
                    s.SwaggerDoc("v1",
                        new OpenApiInfo
                        {
                            Title = "Sistema de controle de Clientes",
                            Version = "v1",
                            Description = "Projeto desenvolvido em NET CORE 3 API com EntityFramework",
                            Contact = new OpenApiContact
                            {
                                Name = "COTI Infromática - Curso de C# WebDeveloper",
                                Url = new Uri("http://www.cotiinformatica.com.br"),
                                Email = "contato@cotiinformatica.com.br"
                            }
                        });
            });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            #region Swagger

            app.UseSwagger();

            app.UseSwaggerUI(s =>
                    { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Aula"); });

            #endregion
        }
    }
}
