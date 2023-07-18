using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Core.Api.Request;
using Smartwyre.DeveloperTest.Core.Services.Interfaces;
using Smartwyre.DeveloperTest.Services;
using System;
using Smartwyre.DeveloperTest.Core.Data.Interfaces;
using Smartwyre.DeveloperTest.DAL.Repository;
using Smartwyre.DeveloperTest.Core.Interfaces;
using Smartwyre.DeveloperTest.Strategies;
using Smartwyre.DeveloperTest.DAL;
using Microsoft.EntityFrameworkCore;

namespace Smartwyre.DeveloperTest.Runner;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter rebate indentifier:");

        string rebateIdentifier = Console.ReadLine();

        Console.WriteLine("Enter product indentifier:");

        string productIdentifier = Console.ReadLine();

        Console.WriteLine("Enter volume:");

        string volumeInput = Console.ReadLine();
        decimal volume;

        Decimal.TryParse(volumeInput, out volume);

        var rebateResponse = GetRebateService().Calculate(
            new CalculateRebate { 
                RebateIdentifier = rebateIdentifier, 
                ProductIdentifier = productIdentifier, 
                Volume = volume 
            });

        Console.WriteLine(rebateResponse.Success ? "The rebate calculation was successful" : "The rebate calculation was not successful");
        Console.ReadLine();
    } 

    private static IRebateService GetRebateService()
    {
        var serviceProvider = new ServiceCollection()
            .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IRebateRepository, RebateRepository>()
            .AddScoped<IIncentiveStrategyFactory, IncentiveStrategyFactory>()
            .AddDbContext<DeveloperTestContext>(options =>
                options.UseSqlServer("Fake connection string"))
            .AddScoped<IRebateService, RebateService>()
            .BuildServiceProvider();

        return serviceProvider.GetService<IRebateService>();
    }
}
