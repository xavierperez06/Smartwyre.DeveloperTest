using Smartwyre.DeveloperTest.Core.Data.Models;

namespace Smartwyre.DeveloperTest.Core.Data.Interfaces
{
    public interface IRebateRepository
    {
        Rebate GetRebate(string identifier);
        void StoreCalculationResult(Rebate account, decimal rebateAmount);
    }
}
