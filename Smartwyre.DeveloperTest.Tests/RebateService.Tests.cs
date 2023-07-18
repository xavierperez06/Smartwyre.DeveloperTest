using Moq;
using Smartwyre.DeveloperTest.Core.Data.Interfaces;
using Smartwyre.DeveloperTest.Core.Data.Models;
using Smartwyre.DeveloperTest.Core.Interfaces;
using Smartwyre.DeveloperTest.Core.Services.Interfaces;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Strategies;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateServiceTests
{
    IRebateService _rebateService;
    private Mock<IProductRepository> _mockProductRepository;
    private Mock<IRebateRepository> _mockRebateRepository;
    private Mock<IIncentiveStrategyFactory> _mockIncentiveFactory;

    public RebateServiceTests()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockRebateRepository = new Mock<IRebateRepository>();
        _mockIncentiveFactory = new Mock<IIncentiveStrategyFactory>();
    }

    private RebateService ConfigureAndGetRebateServie(Rebate rebate, Product product, IIncentiveStrategy incentiveStrategy)
    {
        _mockProductRepository.Setup(p => p.GetProductByIdentifier(It.IsAny<string>())).Returns(product);
        _mockRebateRepository.Setup(r => r.GetRebate(It.IsAny<string>())).Returns(rebate);
        _mockIncentiveFactory.Setup(i => i.CreateStrategy(It.IsAny<Core.Utils.Enums.IncentiveType>())).Returns(incentiveStrategy);

        return new RebateService(_mockProductRepository.Object, _mockRebateRepository.Object, _mockIncentiveFactory.Object);
    }

    [Fact]
    public void RebateCalculationShouldReturnSuccessEqualsTrue()
    {
        var mockedProduct = new Product
        {
            Id = 1,
            Identifier = "Product 1",
            Price = 200,
            SupportedIncentives = Core.Utils.Enums.SupportedIncentiveType.FixedRateRebate,
            Uom = "UOM"
        };

        var mockedRebate = new Rebate
        {
            Identifier = "Rebate 1",
            Amount = 12.3m,
            Incentive = Core.Utils.Enums.IncentiveType.FixedRateRebate,
            Percentage = 20
        };

        var rebateService = ConfigureAndGetRebateServie(mockedRebate, mockedProduct, new FixedRateStrategy());

        var request = new Core.Api.Request.CalculateRebate 
        { ProductIdentifier = "Product 1",
            RebateIdentifier = "Rebate 1", 
            Volume = 20 
        };

        var rebateCalculationResult = rebateService.Calculate(request);

        Assert.True(rebateCalculationResult.Success);
    }

    [Fact]
    public void RebateCalculationShouldReturnSuccessEqualFalse()
    {
        var mockedProduct = new Product
        {
            Id = 1,
            Identifier = "Product 2",
            Price = 300,
            SupportedIncentives = Core.Utils.Enums.SupportedIncentiveType.FixedRateRebate,
            Uom = "UOM"
        };

        var mockedRebate = new Rebate
        {
            Identifier = "Rebate 1",
            Amount = 12.3m,
            Incentive = Core.Utils.Enums.IncentiveType.AmountPerUom,
            Percentage = 20
        };

        var rebateService = ConfigureAndGetRebateServie(mockedRebate, mockedProduct, new AmountPerUomStrategy());

        var request = new Core.Api.Request.CalculateRebate
        {
            ProductIdentifier = "Product 1",
            RebateIdentifier = "Rebate 1",
            Volume = 20
        };

        var rebateCalculationResult = rebateService.Calculate(request);

        Assert.False(rebateCalculationResult.Success);
    }
}
