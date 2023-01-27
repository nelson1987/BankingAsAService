using AutoMapper;
using Baas.Api.Filters;
using Baas.Domain.Commands;
using Baas.Domain.Repositories.Contracts;
using Baas.Infra.DbContext;
using Baas.Infra.Repositories;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Reflection;

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
            //services.AddTransient<ICreatedAccountEventRepository, CreatedAccountEventRepository>();

            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<ITransactionRepository, TransactionRepository>();

            //RabbitMQManager.ConfigureRabbitMQ();
            //services.AddRabbitMq(Configuration, (ContextBoundObject, configurator) =>
            //{
            //    configurator.ConfigureProducer<ICreatedAccountEvent>(new ExchangeConfiguration { Name = "Accounts" });
            //});

            //BusControl = MassTransitConfig.ConfigureBus();
            //BusControl.Start();

            services.AddMassTransit(bus =>
            {
                bus.UsingRabbitMq((ctx, busConfigurator) =>
                {
                    busConfigurator.Host(Configuration.GetConnectionString("RabbitMq"));
                });
            });
            services.AddOptions<MassTransitHostOptions>()
             .Configure(options =>
             {
                 // if specified, waits until the bus is started before
                 // returning from IHostedService.StartAsync
                 // default is false
                 options.WaitUntilStarted = true;

                 // if specified, limits the wait time when starting the bus
                 options.StartTimeout = TimeSpan.FromSeconds(10);

                 // if specified, limits the wait time when stopping the bus
                 options.StopTimeout = TimeSpan.FromSeconds(30);
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
/*
public class MassTransitConfig
{
    public static IBusControl ConfigureBus()
    {
        return Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri("rabbitmq://localhost"), h =>
               {
                   h.Username("guest");
                   h.Password("guest");
               });
            cfg.ReceiveEndpoint("Accounts", e =>
            {
                e.Consumer<MyConsumer>();
            });
        });
    }
}
public class MyConsumer : IConsumer
{
}
public static class RabbitMQConfiguration
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services,
        IConfiguration configuration,
        Action<IBusRegistrationContext, IRabbitMqBusFactoryConfigurator> configureBus = null,
        Action<IBusRegistrationConfigurator>? configureMassTransit = null
        )
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            configureMassTransit?.Invoke(x);

            x.UsingRabbitMq((context, configurator) =>
            {
                configurator.Host("localhost",
                    virtualHost: "/",
                    host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                        host.Heartbeat(600);
                    });
                configureBus?.Invoke(context, configurator);
            });
        });
        return services;
    }
    public static IRabbitMqBusFactoryConfigurator ConfigureProducer<TMessage>(
        this IRabbitMqBusFactoryConfigurator options,
        bool durable = true,
        string exchangeType = ExchangeType.Fanout,
        string? exchangeName = default
        )
    where TMessage : class
    {
        var config = new ExchangeConfiguration
        {
            Durable = durable,
            ExchangeType = exchangeType
        };

        if (string.IsNullOrEmpty(exchangeName) is false)
            config.Name = exchangeName;

        return options.ConfigureProducer<TMessage>(config);

    }
    public static IRabbitMqBusFactoryConfigurator ConfigureProducer<TMessage>(this IRabbitMqBusFactoryConfigurator options,
        ExchangeConfiguration? configuration)
    where TMessage : class
    {
        if (configuration == null)
            return options;

        if (string.IsNullOrEmpty(configuration.Name) is false)
            options.Message<TMessage>(x => x.SetEntityName(configuration.Name));

        options.Publish<TMessage>(topology =>
        {
            topology.Durable = configuration.Durable;
            topology.ExchangeType = configuration.ExchangeType;
        });
        return options;
    }
    public class ExchangeConfiguration
    {
        private const string FANOUT = "fanout";
        public string Name { get; set; }
        public bool Durable { get; set; }
        public string ExchangeType { get; set; } = FANOUT;
        public string RoutingKey { get; set; }

    }
}
*/