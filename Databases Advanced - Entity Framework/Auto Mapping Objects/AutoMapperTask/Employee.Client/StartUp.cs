using System;
using AutoMapper;
using Employee.Client.Core;
namespace Employee.Client
{
    using Employee.Data;
    using Employee.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider service = ConfifureService();

            var engine  = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfifureService()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<AutoMapeprDBContext>(option => option.UseSqlServer(Configurations.ConnectionString));

            serviceCollection.AddTransient<EmployeeService>();

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<AutoProfile>());

            IServiceProvider serverProvider = serviceCollection.BuildServiceProvider();

            return serverProvider;
        }
    }
}
