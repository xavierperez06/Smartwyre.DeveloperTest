using Smartwyre.DeveloperTest.Core.Data.Interfaces;
using Smartwyre.DeveloperTest.Core.Data.Models;
using Smartwyre.DeveloperTest.Core.Interfaces;
using Smartwyre.DeveloperTest.Core.Services.Interfaces;
using Smartwyre.DeveloperTest.Strategies;
using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IProductRepository _productRepository;
    private readonly IRebateRepository _rebateRepository;
    private readonly IIncentiveStrategyFactory _incentiveStrategyFactory;

    public RebateService(IProductRepository productRepository, IRebateRepository rebateRepository, IIncentiveStrategyFactory incentiveStrategyFactory)
    {
        _productRepository = productRepository;
        _rebateRepository = rebateRepository;
        _incentiveStrategyFactory = incentiveStrategyFactory;
    }

    public Core.Api.Response.CalculateRebate Calculate(Core.Api.Request.CalculateRebate request)
    {
        Product product = _productRepository.GetProductByIdentifier(request.ProductIdentifier);
        Rebate rebate = _rebateRepository.GetRebate(request.RebateIdentifier);

        var result = new Core.Api.Response.CalculateRebate();

        var rebateAmount = 0m;

        result.Success = RebateAmountCalculated(rebate,product,request, ref rebateAmount);

        if (result.Success)
        {
            _rebateRepository.StoreCalculationResult(rebate, rebateAmount);
        }

        return result;
    }

    private bool RebateAmountCalculated(Rebate rebate, Product product, Core.Api.Request.CalculateRebate request, ref decimal rebateAmount)
    {
        var incentiveStrategyContext = GetIncentiveContext(rebate.Incentive);

        if (incentiveStrategyContext != null && incentiveStrategyContext.ShouldCalculateRebate(rebate, product, request))
        {
            rebateAmount = incentiveStrategyContext.CalculateRebateAmount(rebate, product, request);

            return true;
        }

        return false;
    }

    private IncentiveContext GetIncentiveContext(IncentiveType incentiveType)
    {
        IIncentiveStrategy incentivenStrategy = _incentiveStrategyFactory.CreateStrategy(incentiveType);

        return incentivenStrategy == null ? null : new IncentiveContext(incentivenStrategy);
    }
}
