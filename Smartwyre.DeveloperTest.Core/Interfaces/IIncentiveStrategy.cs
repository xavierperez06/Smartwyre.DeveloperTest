using Smartwyre.DeveloperTest.Core.Data.Models;

namespace Smartwyre.DeveloperTest.Core.Interfaces;

public interface IIncentiveStrategy
{
    decimal CalculateRebateAmount(Rebate rebate, Product product, Api.Request.CalculateRebate request);
    bool ShouldCalculateRebate(Rebate rebate, Product product, Api.Request.CalculateRebate request);
}
