using Smartwyre.DeveloperTest.Core.Data.Interfaces;
using Smartwyre.DeveloperTest.Core.Data.Models;

namespace Smartwyre.DeveloperTest.DAL.Repository;

public class ProductRepository : IProductRepository
{
    private readonly DeveloperTestContext _context;

    public ProductRepository(DeveloperTestContext context)
    {
        _context = context;
    }
    public Product GetProductByIdentifier(string identifier)
    {
        // This should be the query to retrieve the product, code removed for brevity 
        //_context.Products
        //    .Where(p => p.Identifier == identifier)
        //    .FirstOrDefault();

        // Returing fixed product just for practicality
        return new Product { 
            Id = 1, 
            Identifier = "123", 
            SupportedIncentives = Core.Utils.Enums.SupportedIncentiveType.FixedRateRebate, 
            Price = 200, 
            Uom = "UOM"
        };
    }
}
