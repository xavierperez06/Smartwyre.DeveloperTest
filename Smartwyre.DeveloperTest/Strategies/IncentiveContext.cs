using Smartwyre.DeveloperTest.Core.Data.Models;
using Smartwyre.DeveloperTest.Core.Interfaces;

namespace Smartwyre.DeveloperTest.Strategies;

public class IncentiveContext
{
    private IIncentiveStrategy _context;

    public IncentiveContext(IIncentiveStrategy strategy)
    {
        _context = strategy;
    }

    public void SetStrategy(IIncentiveStrategy strategy)
    {
        _context = strategy;
    }

    public bool ShouldCalculateRebate(Rebate rebate, Product product, Core.Api.Request.CalculateRebate request)
    {
       return _context.ShouldCalculateRebate(rebate,product,request);
    }

    public decimal CalculateRebateAmount(Rebate rebate, Product product, Core.Api.Request.CalculateRebate request)
    {
        return _context.CalculateRebateAmount(rebate,product,request);
    }
     
}   
