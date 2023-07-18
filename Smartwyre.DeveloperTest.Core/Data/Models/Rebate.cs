using static Smartwyre.DeveloperTest.Core.Utils.Enums;

namespace Smartwyre.DeveloperTest.Core.Data.Models;

public class Rebate
{
    public string Identifier { get; set; }
    public IncentiveType Incentive { get; set; }
    public decimal Amount { get; set; }
    public decimal Percentage { get; set; }
}
