using Smartwyre.DeveloperTest.Core.Interfaces;
using Smartwyre.DeveloperTest.Core.Utils;
using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Strategies;

public class IncentiveStrategyFactory : IIncentiveStrategyFactory
{
    public IIncentiveStrategy CreateStrategy(Enums.IncentiveType incentiveType)
    {
        switch (incentiveType)
        {
            case IncentiveType.FixedCashAmount:
                return new FixedAmountStrategy();
            case IncentiveType.FixedRateRebate:
                return new FixedRateStrategy();
            case IncentiveType.AmountPerUom:
                return new AmountPerUomStrategy();
            default: return null;
        }
    }
}
