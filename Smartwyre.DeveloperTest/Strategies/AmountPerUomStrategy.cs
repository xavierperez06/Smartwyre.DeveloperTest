using Smartwyre.DeveloperTest.Core.Api.Request;
using Smartwyre.DeveloperTest.Core.Data.Models;
using Smartwyre.DeveloperTest.Core.Interfaces;
using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Strategies;

public class AmountPerUomStrategy : IIncentiveStrategy
{
    public decimal CalculateRebateAmount(Rebate rebate, Product product, CalculateRebate request)
    {
        return rebate.Amount * request.Volume;
    }

    public bool ShouldCalculateRebate(Rebate rebate, Product product, CalculateRebate request)
    {
        return rebate != null && 
            product != null && 
            product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom) && 
            rebate.Amount != 0 && request.Volume != 0;
    }
}
