using AutoMapper;
using Baas.Api.Filters;
using Baas.Domain.Commands;
using Baas.Domain.Entities;
using Baas.Domain.Repositories.Contracts;
using Baas.Infra.DbContext;
using Baas.Infra.Repositories;
using BAAS.Domain.Consumers;
using BAAS.Domain.Produces;
using BAAS.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Reflection;
using System.Text;

namespace Baas.Api
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
            services.AddControllers(options =>
            {
                options.Filters.Add<HttpResponseExceptionFilter>();
                options.Filters.Add<HttpResponseDomainExceptionFilter>();
                //options.Filters.Add<InactivedEndpointAttribute>();
            });
            services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            services.AddMediatR(AppDomain.CurrentDomain.Load("Baas.Domain"));
            services.AddMediatR(typeof(AberturaContaCommand).GetTypeInfo().Assembly);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Baas.Api", Version = "v1" }));

            services.AddScoped<DbSession>();
            services.AddScoped<MongoDbSession>();
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddTransient<ICreatedAccountEventRepository, CreatedAccountEventRepository>();
            services.AddTransient<IEnterpriseRepository, EnterpriseRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IBusMessage, ProcudeMessage>();
            //services.AddScoped<IPublishEndpoint>();
            //services.AddTransient<ICreatedAccountEventRepository, CreatedAccountEventRepository>();

            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<ITransactionRepository, TransactionRepository>();

            #region

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        //ValidIssuer = Configuration["Jwt:Issuer"],
                        //ValidAudience = Configuration["Jwt:Audience"],
                        //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            #endregion
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();
                x.AddConsumer<ContaAbertaConsumer>(typeof(ContaAbertaConsumerDefinition));

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoToCommand>();
                cfg.AddProfile<ModelToResponse>();
            });
            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Baas.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}