using Microsoft.EntityFrameworkCore;
using Smartwyre.DeveloperTest.Core.Data.Interfaces;
using Smartwyre.DeveloperTest.Core.Data.Models;

namespace Smartwyre.DeveloperTest.DAL.Repository
{
    public class RebateRepository : IRebateRepository
    {
        private readonly DeveloperTestContext _context;

        public RebateRepository(DeveloperTestContext context)
        {
            _context = context;
        }
        public Rebate GetRebate(string identifier)
        {
            // This should be the query to retrieve the product, code removed for brevity 
            //_context.Rebate
            //    .Where(p => p.Identifier == identifier)
            //    .FirstOrDefault();

            // Returing fixed product just for practicality
            return new Rebate {
                Identifier = "234", 
                Amount = 12.3m, 
                Incentive = Core.Utils.Enums.IncentiveType.FixedRateRebate, 
                Percentage = 20
            };
        }

        public void StoreCalculationResult(Rebate rebate, decimal rebateAmount)
        {
            //var rebateEntity = _context.Attach(rebate);
            //rebateEntity.State = EntityState.Modified;

            //int recordsChanged = _context.SaveChanges();

            //if (recordsChanged == 0)
            //{
            //    throw new BaseException("Rebate not found.");
            //}
        }
    }
}
