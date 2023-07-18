using Smartwyre.DeveloperTest.Core.Api.Request;
using Smartwyre.DeveloperTest.Core.Data.Models;
using Smartwyre.DeveloperTest.Core.Interfaces;
using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Strategies;

public class FixedRateStrategy : IIncentiveStrategy
{
    public decimal CalculateRebateAmount(Rebate rebate, Product product, CalculateRebate request)
    {
        return product.Price * rebate.Percentage * request.Volume;
    }

    public bool ShouldCalculateRebate(Rebate rebate, Product product, CalculateRebate request)
    {
        return rebate != null && 
            product != null && 
            product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate) && 
            rebate.Percentage != 0 && product.Price != 0 && request.Volume != 0;
    }
}
