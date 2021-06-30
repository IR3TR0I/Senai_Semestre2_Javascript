using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Senai.SPMGMobile.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                // Adiciona os Controllers
                .AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    //Ignora Looping em consultas
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //Ignora Valor nulo quando faz junção na consulta
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => {
                        builder.WithOrigins("http://localhost:3000", "http://localhost:19006")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    }
                );
            });

            //Documentação Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpMedicalGroup.webAPI", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services
                //Autenticação
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //emissor validado
                        ValidateIssuer = true,
                        //audience Validado
                        ValidateAudience = true,
                        //tempo de vida validado
                        ValidateLifetime = true,
                        // forma e tipo de criptografia e chave de autenticação
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmedgroup-chave-autenticacao")),
                        //tempo para token expirar
                        ClockSkew = TimeSpan.FromMinutes(30),
                        //nome do emissor de onde vem
                        ValidIssuer = "SpMedGroup.webAPI",
                        //nome da audience para onde vai
                        ValidAudience = "SpMedGroup.webAPI"
                    };

                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SpMedGroup.webApi V1");
                c.RoutePrefix = string.Empty; //colocar o Swagger como pagina inicial da Documentação
            });


            app.UseRouting();

           //Habilita a authenticação
            app.UseAuthentication();

            //Habilita a Autorização
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //Mapeamento De Controladores
                endpoints.MapControllers();
            });
        }
    }
}
