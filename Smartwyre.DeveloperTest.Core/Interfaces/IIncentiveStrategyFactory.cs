using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Core.Interfaces
{
    public interface IIncentiveStrategyFactory
    {
        IIncentiveStrategy CreateStrategy(IncentiveType incentiveType);
    }
}
