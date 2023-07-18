using Smartwyre.DeveloperTest.Core.Data.Models;
using Smartwyre.DeveloperTest.Core.Interfaces;
using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Strategies;

public class FixedAmountStrategy : IIncentiveStrategy
{
    public decimal CalculateRebateAmount(Rebate rebate, Product product, Core.Api.Request.CalculateRebate request)
    {
        return rebate.Amount;
    }

    public bool ShouldCalculateRebate(Rebate rebate, Product product, Core.Api.Request.CalculateRebate request)
    {
        return rebate != null && !product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount) && rebate.Amount != 0;
    }
}
