using Smartwyre.DeveloperTest.Core.Data.Models;

namespace Smartwyre.DeveloperTest.Core.Data.Interfaces;

public interface IProductRepository
{
    Product GetProductByIdentifier(string identifier);
}
